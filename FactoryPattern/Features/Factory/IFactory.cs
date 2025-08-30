namespace FactoryPattern.Features.Factory
{
    internal interface IFactory
    {
        ILogistics CreateInstance();
    }
}
