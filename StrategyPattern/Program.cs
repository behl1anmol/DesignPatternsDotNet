using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StrategyPattern;
using StrategyPattern.Factory;
using StrategyPattern.Models;
using StrategyPattern.Strategies;

var serviceProvider = new ServiceCollection()
    .AddLogging(options =>
    {
        options.ClearProviders();
        options.AddConsole();
    })
    .AddSingleton<Application>()
    .AddSingleton<Catalog>()
    .AddTransient<Cart>()
    .AddTransient<IPaymentStrategy, CashPaymentStrategy>()
    .AddTransient<IPaymentStrategy, CreditCardPaymentStrategy>()
    .AddSingleton<IPaymentStrategyFactory, PaymentStrategyFactory>()
    .BuildServiceProvider();

Application app = serviceProvider.GetRequiredService<Application>();
app.RunAsync();

