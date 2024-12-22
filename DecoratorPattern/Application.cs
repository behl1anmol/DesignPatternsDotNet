using DecoratorPattern.Decorators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DecoratorPattern
{
    public class Application
    {
        private readonly ICoffeeBase _CaramelCoffee;
        private readonly ICoffeeBase _WhippedCreamCoffee;
        private readonly ILogger<Application> _Logger;
        public Application([FromKeyedServices(typeof(CaramelCoffee))] ICoffeeBase coffeeBase
                           , [FromKeyedServices(typeof(WhippedCreamCoffee))] ICoffeeBase whippedCreamCoffeeBase
                           , ILogger<Application> logger)
        {
            _CaramelCoffee = coffeeBase;
            _WhippedCreamCoffee = whippedCreamCoffeeBase;
            _Logger = logger;
        }

        public void Run()
        {
            _Logger.LogInformation("Caramel Coffee");
            Console.WriteLine($"Cost: {_CaramelCoffee.GetCost()}");
            Console.WriteLine($"Ingredients: {_CaramelCoffee.GetIngredients()}");
            _Logger.LogInformation("Whipped Cream Coffee");
            Console.WriteLine($"Cost: {_WhippedCreamCoffee.GetCost()}");
            Console.WriteLine($"Ingredients: {_WhippedCreamCoffee.GetIngredients()}");
        }
    }
}
