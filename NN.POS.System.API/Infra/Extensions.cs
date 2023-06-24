using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using NN.POS.System.API.Core;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.API.Core.Exceptions.Middleware;
using NN.POS.System.API.Core.Exceptions.Roles;
using NN.POS.System.API.Core.Exceptions.Users;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Core.Middleware;
using NN.POS.System.API.Core.Middleware.Logging;
using NN.POS.System.API.Infra.Repositories.Users;
using NN.POS.System.API.Infra.Swagger;
using NN.POS.System.API.Infra.Swagger.CustomizeHeader;
using NN.POS.System.API.Infra.Tables;

namespace NN.POS.System.API.Infra;

public static class Extensions
{
    public static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSetting = configuration.GetSection("AppSetting:Jwt").Get<JwtSetting>() ?? new JwtSetting();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtSetting.Audience,
                    ValidIssuer = jwtSetting.Site,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SigningKey)),
                    ValidateLifetime = false
                };
            });
        return services;
    }
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new AppSettings();
        configuration.GetSection("AppSetting").Bind(settings);
        services.AddSingleton(settings);
        services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
        services.AddTransient<ITokenProvider, TokenProvider>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSqlServerDatabase<DataDbContext>()
            .AddDataDbRepositories()
            .AddJwtAuth(configuration)
            .Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.All;
            });
        if (settings.Swagger.IsEnable)
        {
            services.AddSwagger<AuthorizationHeaderParameterOperationFilter>("NN.POS.System.Api.xml");
        }
        return services;
    }

    public static WebApplication UseCustomSwagger(this WebApplication app)
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "swagger/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(c =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }

            c.RoutePrefix = "swagger";
        });
        return app;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseErrorHandler()
        .UseMiddleware<AuthorizationRequestHandlerMiddleware>()
        .UseMiddleware<LogMiddleware>()
        .UseAllForwardedHeaders()
        .UseLogUserIdMiddleware();

        _ = app.InitUser();
        return app;
    }

    private static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
    private static IApplicationBuilder UseAllForwardedHeaders(this IApplicationBuilder builder)
    {
        return builder.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
    }

    private static void UseLogUserIdMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<LogUserIdMiddleware>();
    }

    private static async Task<WebApplication> InitUser(this WebApplication app)
    {
        var userRepository = app.Services.GetService<IUserRepository>();
        var userRoleRepository = app.Services.GetService<IUserRoleRepository>();
        var roleRepository = app.Services.GetService<IRoleRepository>();
        var passHasher = app.Services.GetService<IPasswordHasher<UserEntity>>();
        if (userRepository is null || passHasher is null || roleRepository is null || userRoleRepository is null) return app;
        
        var isHasRole = await roleRepository.IsHasRoleAsync();
        var userId = 0;
        var roleId = 0;
        if (!isHasRole)
        {
            var roleEn = new RoleEntity("Admin", DateTime.UtcNow, DateTime.Now)
            {
                DisplayName = "Administrator",
                Description = "These role can perform any operations"
            };
            var role = await roleRepository.CreateRoleAsync(roleEn);
            roleId = role.Id;
        }

        var isHasUser = await userRepository.HasUserAsync();
        if (!isHasUser)
        {
            var uEntity = new UserEntity(name: "ADMIN", username: "ADMIN", email: "admin@gmail.com", lastLogin: null,
                createdAt: DateTime.UtcNow, updatedAt: DateTime.UtcNow);
            uEntity.SetPassword("Admin123", passHasher);
            var user = await userRepository.CreateUserAsync(uEntity);
            userId = user.Id;
        }

        if (userId == 0 || roleId == 0)
        {

            var role = await roleRepository.GetRoleByNameAsync("Admin");
            if (role is not null)
                roleId = role.Id;
            else
                throw new RoleNotFoundException("Admin");

            var user = await userRepository.GetByUserNameAsync("ADMIN");
            if (user is not null)
                userId = user.Id;
            else
                throw new UserNotFoundException("ADMIN");
        }

        await userRoleRepository.AddRoleToUserAsync(userId: userId, roleId: roleId);
        return app;
    }
}