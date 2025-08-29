using AbstractFactoryPattern.Features.Interfaces;

namespace AbstractFactoryPattern.Factory
{
    internal interface IAbstractFactory
    {
        IChair CreateChair(Type type);
        ITable CreateTable(Type type);
    }
}
