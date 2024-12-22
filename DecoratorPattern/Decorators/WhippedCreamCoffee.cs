using DecoratorPattern.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DecoratorPattern.Decorators
{
    public class WhippedCreamCoffee : ICoffeeBase
    {
        private readonly CoffeeModel _WhippedCreamCoffeeModel;
        private readonly ICoffeeBase _Coffee;
        public WhippedCreamCoffee([FromKeyedServices(typeof(CoffeeBase))] ICoffeeBase coffee, CoffeeModel coffeeModel)
        {
            _Coffee = coffee;
            _WhippedCreamCoffeeModel = coffeeModel;
            _WhippedCreamCoffeeModel.Cost = 3.50;
            _WhippedCreamCoffeeModel.CoffeeIngredients = new List<string>
                                                {
                                                    Ingredients.Milk,
                                                    Ingredients.WhippedCream
                                                };
        }
        public double GetCost()
        {
            return _Coffee.GetCost() + _WhippedCreamCoffeeModel.Cost;
        }
        public string GetIngredients()
        {
            if (_Coffee.GetIngredients() != string.Empty)
            {
                return $"{_Coffee.GetIngredients()}, {string.Join(", ", _WhippedCreamCoffeeModel.CoffeeIngredients)}";
            }
            else
            {
                return string.Join(", ", _WhippedCreamCoffeeModel.CoffeeIngredients);
            }
        }
    }
}
