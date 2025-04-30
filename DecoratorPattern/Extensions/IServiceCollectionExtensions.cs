using Microsoft.Extensions.DependencyInjection;

namespace DecoratorPattern.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection Decorate<IService, TDecorator, TFinal>(this IServiceCollection services, object key, object decKey)
            where TDecorator : class, IService
            where TFinal : class, IService
            where IService : class
        {
            services.AddKeyedSingleton<IService, TFinal>(key);
            services.AddKeyedSingleton<IService, TDecorator>(decKey);
            return services;
        }

    }
}
