using DecoratorPattern;
using DecoratorPattern.Decorators;
using DecoratorPattern.Extensions;
using DecoratorPattern.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceProvider = new ServiceCollection()
    .AddLogging(options =>
    {
        options.ClearProviders();
        options.AddConsole();
    })
    .AddTransient<CoffeeModel>()
    .Decorate<ICoffeeBase, CaramelCoffee, CoffeeBase>(typeof(CoffeeBase), typeof(CaramelCoffee))
    .Decorate<ICoffeeBase, WhippedCreamCoffee, CoffeeBase>(typeof(CoffeeBase), typeof(WhippedCreamCoffee))
    .AddSingleton<Application>()
    .BuildServiceProvider();


var app = serviceProvider.GetRequiredService<Application>();
app.Run();

