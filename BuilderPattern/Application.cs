using BuilderPattern.Interfaces;
using BuilderPattern.Models;
using Microsoft.Extensions.Logging;

namespace BuilderPattern;

public class Application
{
    private readonly IFurnitureInventoryBuilder furnitureInventoryBuilder;
    private readonly ILogger<Application> logger;
    private readonly InventoryReport _report;
    public Application(IFurnitureInventoryBuilder _furnitureInventoryBuilder,
        IServiceProvider _serviceProvider,
        ILogger<Application> _logger,
        InventoryReport report)
    {
        furnitureInventoryBuilder = _furnitureInventoryBuilder;
        logger = _logger;
        _report = report;
    }
    public void RunAsync()
    {
        logger.LogInformation("Building: Inventory Report");

        var report = furnitureInventoryBuilder
            .AddTitle()
            .AddDimensions()
            .AddLogistics(DateTime.Now)
            .Build();
        logger.LogInformation("Created: Inventory Report");

        report.Debug();

        logger.LogInformation("Created: Inventory Report registered via builder");

        _report.Debug();
    }
}