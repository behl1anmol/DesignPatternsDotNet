namespace BuilderPattern.Models
{
    public class InventoryReport
    {
        public string Title { get; set; }
        public string Dimensions { get; set; }
        public string Logistics { get; set; }

        public void Debug()
        {
            Console.WriteLine("Inventory Report:");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Dimensions: {Dimensions}");
            Console.WriteLine($"Logistics: {Logistics}");
        }
    }
}
