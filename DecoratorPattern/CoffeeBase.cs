using DecoratorPattern.Models;

namespace DecoratorPattern
{
    public class CoffeeBase : ICoffeeBase
    {
        public CoffeeModel Coffee { get; set; }
        public CoffeeBase()
        {
            Coffee = new CoffeeModel();
            Coffee.Cost = 1.00;
            Coffee.CoffeeIngredients = new List<string> {
                                            Ingredients.CoffeeBeans,
                                            Ingredients.Water,
                                            Ingredients.Sugar
                                        };
        }
        public double GetCost()
        {
            return Coffee.Cost;
        }
        public string GetIngredients()
        {
            if (Coffee.CoffeeIngredients != null)
            {
                return string.Join(", ", Coffee.CoffeeIngredients);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
