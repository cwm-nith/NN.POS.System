using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NN.POS.System.Core;
using NN.POS.System.Core.Entities.Users;
using NN.POS.System.Core.Exceptions.Middleware;
using NN.POS.System.Core.IRepositories.Users;
using NN.POS.System.Core.Middleware;
using NN.POS.System.Core.Middleware.Logging;
using NN.POS.System.Infrastructure.Repositories.Users;
using NN.POS.System.Infrastructure.Swagger;
using NN.POS.System.Infrastructure.Swagger.CustomizeHeader;
using NN.POS.System.Infrastructure.Swagger.RequestExamples;
using NN.POS.System.Infrastructure.Tables;

namespace NN.POS.System.Infrastructure;

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
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SigningKey ?? "")),
                    ValidateLifetime = false
                };
            });
        return services;
    }
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
        services.AddTransient<ITokenProvider, TokenProvider>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSqlServerDatabase<DataDbContext>()
            .AddDataDbRepositories()
            .AddJwtAuth(configuration)
            .AddDataDbRepositories()
            .AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            })
            .AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            })
            .AddSwagger<AuthorizationHeaderParameterOperationFilter>("NN.POS.System.Api.xml")
            .AddSwaggerExample()
            .Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.All;
            });
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

    private static IApplicationBuilder UseLogUserIdMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogUserIdMiddleware>();
    }
}