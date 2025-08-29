using AbstractFactoryPattern.Features.Interfaces;

namespace AbstractFactoryPattern.Features
{
    internal class ModernTableFurniture : ITable
    {
        public string DisplayMessage() => "This is a Modern Table";
    }
}
