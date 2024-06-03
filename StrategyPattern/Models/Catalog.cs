namespace StrategyPattern.Models;

public class Catalog
{
    public List<Item> Items { get; set; } = new List<Item>();

    public Catalog()
    {
        Items.Add(new Item { Name = "Lenovo Ideapad 320", Price = 50000 , Quantity = 20});
        Items.Add(new Item { Name = "Dell Inspiron 15", Price = 60000 , Quantity = 10});
        Items.Add(new Item { Name = "HP Pavilion", Price = 55000 , Quantity = 15});
        Items.Add(new Item { Name = "Asus Zenbook", Price = 70000, Quantity = 5 });
        Items.Add(new Item { Name = "Macbook M1", Price = 70000, Quantity = 25 });
    }
}