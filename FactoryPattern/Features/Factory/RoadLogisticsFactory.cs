namespace FactoryPattern.Features.Factory
{
    internal class RoadLogisticsFactory : IFactory
    {
        public ILogistics CreateInstance()
        {
            var logistics = new RoadLogistics();
            logistics.Message = "Factory created Road Logistics instance.";
            return logistics;
        }
    }
}
