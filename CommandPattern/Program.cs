using System.Data;
using CommandPattern;
using CommandPattern.Commands;
using CommandPattern.Context;
using CommandPattern.Manager;
using CommandPattern.Models;
using CommandPattern.Repository;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddLogging(options =>
    {
        options.ClearProviders();
        options.AddConsole();
    })
    .AddSingleton<Application>()
    .AddSingleton<CommandManager>()
    .AddTransient<ICommand, SaveTransactionCommand>()
    .AddSingleton<IRepository, TransactionRepository>()
    .AddSingleton<DbContext>()
    .AddScoped<TransactionEntity>()
    
    /*.AddTransient<Func<Type, ICommand>>(serviceProvider => type =>
    {
        if (type == typeof(SaveTransactionCommand))
        {
            var rep = serviceProvider.GetRequiredService<IRepository>();
            var ety = serviceProvider.GetRequiredService<TransactionEntity>();
            return new SaveTransactionCommand(rep, ety);
        }
        else if (type == typeof(GetTransactionCommand))
        {
            var dep = serviceProvider.GetRequiredService<ILogger<FanRepository>>();
            var model = serviceProvider.GetRequiredService<FanModel>() as IModel;
            return new FanRepository(model, dep);
        }
        else
        {
            throw new ArgumentException("Invalid Type requested");
        }
    })*/
    .BuildServiceProvider();

var app = serviceProvider.GetRequiredService<Application>();
app.RunAsync();