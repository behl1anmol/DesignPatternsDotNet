using AbstractFactoryPattern.Features.Interfaces;

namespace AbstractFactoryPattern.Features
{
    internal class ModernChairFurniture : IChair
    {
        public string DisplayMessage() => "This is a Modern Chair";
    }
}
