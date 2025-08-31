using AdapterPattern.Features.Interfaces;

namespace AdapterPattern.Features
{
    public class RoundPeg : IRoundPeg
    {
        private double _radius;
        public double Radius
        {
            get => _radius;
            private set => _radius = value;
        }
        public double GetRadius()
        {
            return _radius;
        }

        public void SetRadius(double radius)
        {
            Radius = radius;
        }
    }
}
