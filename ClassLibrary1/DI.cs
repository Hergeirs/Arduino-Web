using ArduinoObserver;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace E.Gardener.Services
{
    public static class MyServiceExtensions 
    {
        public static void AddObserverLibrary(this IServiceCollection services)
        {
            services.TryAddTransient<Observer>();
            services.TryAddTransient<DataPusherObserver>();
            services.AddHostedService<Observable>(); 
        }
    }
}