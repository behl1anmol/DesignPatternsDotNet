namespace FactoryPattern.Features
{
    internal class RoadLogistics : Logistics<RoadLogistics>, IRoadLogistics
    {
        public override string Message { get; set; } = null!;

        public override string GetInfo()
        {
            base.GetInfo();
            return $"Road Logistics feature invoked with message: {Message}";
        }
    }
}
