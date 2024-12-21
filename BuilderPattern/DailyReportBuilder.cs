using BuilderPattern.Interfaces;
using BuilderPattern.Models;

namespace BuilderPattern
{
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private List<FurnitureItem> _items;
        private InventoryReport _report;
        public DailyReportBuilder(List<FurnitureItem> items)
        {
            Reset();
            _items = items;
        }
        public IFurnitureInventoryBuilder AddTitle()
        {
            _report.Title = "Daily Inventory Report";
            return this;
        }
        public IFurnitureInventoryBuilder AddDimensions()
        {
            _report.Dimensions = string.Join("\n",
                                       _items.Select(item => $"Product: {item.Name}, Material: {item.Material}, Size: {item.Size}"));
            return this;
        }
        public IFurnitureInventoryBuilder AddLogistics(DateTime dateTime)
        {
            _report.Logistics = $"Logistics for {dateTime}";
            return this;
        }
        public InventoryReport Build()
        {
            var finishedReport = _report;
            Reset();
            return finishedReport;
        }

        public void Reset()
        {
            _report = new InventoryReport();
        }
    }
}
