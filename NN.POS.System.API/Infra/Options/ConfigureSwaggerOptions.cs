using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NN.POS.System.API.Core;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NN.POS.System.API.Infra.Options;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, AppSettings appSettings) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }

    private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo { Title = appSettings.Swagger.Name ?? "NN.POS.System", Version = description.ApiVersion.ToString() };
        return info;
    }
}