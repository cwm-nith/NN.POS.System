using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace NN.POS.System.Infrastructure.Swagger;

public static class Extensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, string docFileName)
    {
        services.AddSwaggerGen(c =>
        {
            c.ExampleFilters();
            c.OperationFilter<AddResponseHeadersFilter>();

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            //c.OperationFilter()
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                        { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } },
                    new List<string>()
                }
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, docFileName);
            c.IncludeXmlComments(filePath);
            c.OperationFilter<
                AppendAuthorizeToSummaryOperationFilter>(); 
        });
        services.AddSwaggerExamplesFromAssemblyOf<TestExample>();
        return services;
    }

    public static IServiceCollection AddSwagger<THeader>(this IServiceCollection services, string docFileName)
        where THeader : IOperationFilter
    {
        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            c.ExampleFilters();
            c.OperationFilter<THeader>();
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                        { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } },
                    new List<string>()
                }
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, docFileName);
            c.IncludeXmlComments(filePath);
            c.OperationFilter<
                AppendAuthorizeToSummaryOperationFilter>();
        });
        services.AddSwaggerExamplesFromAssemblyOf<TestExample>();
        return services;
    }
}