using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NN.POS.System.API.Core;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NN.POS.System.API.Infra.Options;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly AppSettings _appSettings;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, AppSettings appSettings)
    {
        _provider = provider;
        _appSettings = appSettings;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }

    private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo { Title = _appSettings.Swagger.Name ?? "NN.POS.System", Version = description.ApiVersion.ToString() };
        return info;
    }
}