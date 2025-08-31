using AdapterPattern.Features.Interfaces;

namespace AdapterPattern.Features
{
    public class RoundHole : IRoundHole
    {
        private double _radius;

        public double Radius
        {
            get { return _radius; }
            private set { _radius = value; }
        }

        public bool Fits(IRoundPeg peg)
        {
            return this.GetRadius() >= peg.GetRadius();
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
