using System.Reflection;

namespace NN.POS.System.API.App;

public static class Extensions
{
    public static IServiceCollection AddRegistrationMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}