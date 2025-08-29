using AbstractFactoryPattern.Features.Interfaces;

namespace AbstractFactoryPattern.Features
{
    internal class VintageChairFurniture : IChair
    {
        public string DisplayMessage() => "This is a Vintage Chair";
    }
}
