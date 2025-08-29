using AbstractFactoryPattern;
using AbstractFactoryPattern.Factory;
using AbstractFactoryPattern.Features;
using AbstractFactoryPattern.Features.Interfaces;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection serviceCollection = new();

serviceCollection.AddSingleton<App>();
serviceCollection.AddSingleton<IAbstractFactory, AbstractFactory>();
serviceCollection.AddKeyedTransient<IChair, ModernChairFurniture>(nameof(ModernChairFurniture));
serviceCollection.AddKeyedTransient<ITable, ModernTableFurniture>(nameof(ModernTableFurniture));
serviceCollection.AddKeyedTransient<IChair, VintageChairFurniture>(nameof(VintageChairFurniture));
serviceCollection.AddKeyedTransient<ITable, VintageTableFurniture>(nameof(VintageTableFurniture));

ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
App app = serviceProvider.GetService<App>()!;

app.Run();
