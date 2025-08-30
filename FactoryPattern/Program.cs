using FactoryPattern;
using FactoryPattern.Features.Factory;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection collection = new ServiceCollection();
collection.AddKeyedSingleton<IFactory, RoadLogisticsFactory>(nameof(RoadLogisticsFactory));
collection.AddKeyedSingleton<IFactory, SeaLogisticsFactory>(nameof(SeaLogisticsFactory));
collection.AddSingleton<App>();
var provider = collection.BuildServiceProvider();

var app = provider.GetRequiredService<App>();
app.Run();


