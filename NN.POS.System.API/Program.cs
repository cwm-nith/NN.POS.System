using NN.POS.System.API.App;
using NN.POS.System.API.Core;
using NN.POS.System.API.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddInfrastructure(builder.Configuration)
    .AddRegistrationMediatR();
var app = builder.Build();

var settings = app.Services.GetService<AppSettings>();
if(settings?.Swagger.IsEnable ?? false) app.UseCustomSwagger();
app.UseHttpsRedirection();

app.UseCors(i => 
        i.AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(_ => true)
    );

app.UseAuthentication();
app.UseAuthorization();

app.UseInfrastructure();

app.MapControllers();

app.Run();
