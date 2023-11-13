using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using NN.POS.System.Web;
using NN.POS.System.Web.AppSettings;
using NN.POS.System.Web.Constants;
using NN.POS.System.Web.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new Setting();

builder.Configuration.GetSection("Setting").Bind(settings);
builder.Services.AddSingleton(settings);

builder.Services.AddHttpClient(AppConstants.HttpClientName, options =>
{
    options.BaseAddress = new Uri(settings.ApiUrl);
}).AddHttpMessageHandler<CustomHttpHandler>();

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomHttpHandler>();

await builder.Build().RunAsync();
