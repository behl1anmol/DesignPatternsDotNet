using BuilderPattern.Models;

namespace BuilderPattern.Interfaces
{
    public interface IFurnitureInventoryBuilder
    {
        IFurnitureInventoryBuilder AddTitle();
        IFurnitureInventoryBuilder AddDimensions();
        IFurnitureInventoryBuilder AddLogistics(DateTime dateTime);
        InventoryReport Build();
    }
}
