using Microsoft.Extensions.Logging;
using StrategyPattern.Models;
using StrategyPattern.Utils;

namespace StrategyPattern;

public class Application(ILogger<Application> logger, Catalog catalog, Cart order)
{
    private Cart Order { get; set; } = order;

    public void RunAsync()
    {
        Console.WriteLine("Welcome to the Strategy Pattern Example!");
        Console.WriteLine("Product Catalog:");
        
        foreach (var item in catalog.Items)
        {
            Console.WriteLine($"- {item.Name} - ${item.Price}");
        }
        
        var random = new Random();
        for (int i = 0; i < 5; i++)
        {
            var item = catalog.Items[random.Next(0, catalog.Items.Count)];
            item.Quantity--;
            Order.Items.Add(item);
        }
        
        Console.WriteLine("\nOrder Summary:");
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
        var paymentMethod = Enum.Parse<PaymentMethod>(Console.ReadLine()??"1");
        
        logger.LogInformation("Processing Payment...");
        Order.PaymentMethod = paymentMethod;
        Console.WriteLine(Order.ProcessPayment() ? "Payment processed successfully!" : "Payment failed!");
        logger.LogInformation("Payment processed successfully...");
    }
}