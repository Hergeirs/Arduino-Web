using ArduinoObserver;
using Microsoft.Extensions.DependencyInjection;

public static class MyServiceExtensions 
{
    public static IServiceCollection AddMyLibrary(this IServiceCollection services)
    {
        services.AddTransient<Observer>();
        services.AddTransient<DataPusherObserver>();
        services.AddHostedService<Observable>(); 
        return services;
    }
}