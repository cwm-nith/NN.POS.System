using System.Reflection;

namespace NN.POS.API.App;

public static class Extensions
{
    public static IServiceCollection AddRegistrationMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}