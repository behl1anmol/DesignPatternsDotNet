using BuilderPattern.Interfaces;
using BuilderPattern.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.DependencyInjection.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddInventoryReportBuilder(this IServiceCollection services)
        {
            services.AddTransient<InventoryReport>(provider =>
            {
                var furnitureInventoryBuilder = provider.GetRequiredService<IFurnitureInventoryBuilder>();
                var logger = provider.GetRequiredService<ILogger<BuilderPattern.Application>>();

                var report = furnitureInventoryBuilder
                    .AddTitle()
                    .AddDimensions()
                    .AddLogistics(DateTime.Now)
                    .Build();

                return report;
            });

            return services;
        }
    }
}
