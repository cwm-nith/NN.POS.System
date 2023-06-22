using NN.POS.System.API.App;
using NN.POS.System.API.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddInfrastructure(builder.Configuration)
    .AddRegistrationMediatR();
var app = builder.Build();

app.UseCustomSwagger();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseInfrastructure();

app.MapControllers();

app.Run();
