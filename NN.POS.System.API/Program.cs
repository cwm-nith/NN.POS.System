using NN.POS.System.Infrastructure;
using NN.POS.System.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
