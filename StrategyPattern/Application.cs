using Microsoft.Extensions.Logging;
using StrategyPattern.Models;
using StrategyPattern.Utils;

namespace StrategyPattern;

public class Application
{
    private readonly ILogger<Application> _logger;
    private readonly Catalog _catalog;
    public Cart Order { get; set; }

    public Application(ILogger<Application> logger, Catalog catalog, Cart order)
    {
        _logger = logger;
        _catalog = catalog;
        Order = order;
    }

    public void RunAsync()
    {
        Console.WriteLine("Welcome to the Strategy Pattern Example!");
        Console.WriteLine("Product Catalog:");
        
        foreach (var item in _catalog.Items)
        {
            Console.WriteLine($"- {item.Name} - ${item.Price}");
        }
        
        //randomly add items to the order
        var random = new Random();
        for (int i = 0; i < 5; i++)
        {
            var item = _catalog.Items[random.Next(0, _catalog.Items.Count)];
            Order.Items.Add(item);
        }
        
        Console.WriteLine("Order Summary:");
        foreach (var item in Order.Items)
        {
            Console.WriteLine($"- {item.Name} - INR. {item.Price}");
        }
        Console.WriteLine($"Order Total: {Order.Total}");
        
        Console.WriteLine("Select a payment method:");
        Console.WriteLine("1. Cash");
        Console.WriteLine("2. Credit Card");
        Console.WriteLine("3. Debit Card");
        Console.WriteLine("4. Net Banking");
        Console.WriteLine("5. Wallet");
        Console.WriteLine("6. UPI");
        var paymentMethod = Enum.Parse<PaymentMethod>(Console.ReadLine());
        
        Order.PaymentMethod = paymentMethod;
        if (Order.ProcessPayment())
        {
            Console.WriteLine("Payment processed successfully!");
        }
        else
        {
            Console.WriteLine("Payment failed!");
        }
        
    }
}