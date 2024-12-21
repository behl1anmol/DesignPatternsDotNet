using BuilderPattern.Interfaces;
using BuilderPattern.Models;
using Microsoft.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BuilderPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(options =>
                {
                    options.ClearProviders();
                    options.AddConsole();
                })
                .AddTransient<IFurnitureInventoryBuilder, DailyReportBuilder>()
                .AddSingleton<List<FurnitureItem>>(new List<FurnitureItem>
                {
                    new FurnitureItem("Chair", "Wood", "45x45x90 cm"),
                    new FurnitureItem("Table", "Metal", "120x60x75 cm"),
                    new FurnitureItem("Sofa", "Fabric", "200x90x85 cm")
                })
                .AddTransient<Application>()
                .AddInventoryReportBuilder()
                .BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<Application>();
            app.RunAsync();
        }
    }
}
