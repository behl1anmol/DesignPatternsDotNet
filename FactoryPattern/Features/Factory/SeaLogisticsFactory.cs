namespace FactoryPattern.Features.Factory
{
    internal class SeaLogisticsFactory : IFactory
    {
        public ILogistics CreateInstance()
        {
            var logistics = new SeaLogistics();
            logistics.Message = "Factory created Sea Logistics instance.";
            return logistics;
        }
    }
}
