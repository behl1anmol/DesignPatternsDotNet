using AbstractFactoryPattern.Features.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AbstractFactoryPattern.Factory
{
    internal class AbstractFactory(IServiceProvider serviceProvider) : IAbstractFactory
    {
        public IChair CreateChair(Type type)
        {
            return serviceProvider.GetKeyedService<IChair>(type.Name) ?? throw new ArgumentException("Invalid chair type", nameof(type));
        }

        public ITable CreateTable(Type type)
        {
            return serviceProvider.GetKeyedService<ITable>(type.Name) ?? throw new ArgumentException("Invalid table type", nameof(type));
        }
    }
}
