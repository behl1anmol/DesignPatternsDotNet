namespace StrategyPattern.Models;

public class Item
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Total => Price * Quantity;
}