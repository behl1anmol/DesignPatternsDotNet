using AbstractFactoryPattern.Features.Interfaces;

namespace AbstractFactoryPattern.Features
{
    internal class VintageTableFurniture : ITable
    {
        public string DisplayMessage() => "This is a Vintage Table";
    }
}
