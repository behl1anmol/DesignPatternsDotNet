using FactoryPattern.Features.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryPattern
{
    internal class App([FromKeyedServices(nameof(RoadLogisticsFactory))] IFactory roadLogisticsFactory
                        , [FromKeyedServices(nameof(SeaLogisticsFactory))] IFactory seaLogisticsFactory)
    {
        public void Run()
        {
            var roadLogistics = roadLogisticsFactory.CreateInstance();
            Console.WriteLine(roadLogistics.GetInfo());
            var seaLogistics = seaLogisticsFactory.CreateInstance();
            Console.WriteLine(seaLogistics.GetInfo());
        }
    }
}
