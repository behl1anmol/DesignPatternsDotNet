namespace FactoryPattern.Features
{
    internal class SeaLogistics : Logistics<SeaLogistics>, ISeaLogistics
    {
        public override string Message { get; set; } = null!;
        public override string GetInfo()
        {
            return $"Sea Logistics feature invoked with message: {Message}";
        }
    }
}
