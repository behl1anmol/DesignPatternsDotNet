using DecoratorPattern.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DecoratorPattern.Decorators
{
    public class CaramelCoffee : ICoffeeBase
    {
        private readonly CoffeeModel _CoffeeModel;
        private readonly ICoffeeBase _Coffee;
        public CaramelCoffee([FromKeyedServices(typeof(CoffeeBase))] ICoffeeBase coffee, CoffeeModel coffeeModel)
        {
            _Coffee = coffee;
            _CoffeeModel = coffeeModel;
            _CoffeeModel.Cost = 4.50;
            _CoffeeModel.CoffeeIngredients = new List<string>
                                                {
                                                    Ingredients.Caramel,
                                                    Ingredients.Milk
                                                };
        }
        public double GetCost()
        {
            return _Coffee.GetCost() + _CoffeeModel.Cost;
        }
        public string GetIngredients()
        {
            if (_Coffee.GetIngredients() != string.Empty)
            {
                return $"{_Coffee.GetIngredients()}, {string.Join(", ", _CoffeeModel.CoffeeIngredients)}";
            }
            else
            {
                return string.Join(", ", _CoffeeModel.CoffeeIngredients);
            }
        }
    }
}
