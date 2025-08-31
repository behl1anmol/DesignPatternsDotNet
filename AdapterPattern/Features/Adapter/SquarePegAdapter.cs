using AdapterPattern.Features.Interfaces;

namespace AdapterPattern.Features.Adapter
{
    public class SquarePegAdapter : ISquarePegAdapter
    {
        private ISquarePeg? _adaptee;

        public double Radius
        {
            get
            {
                ValidateAndThrow();
                return _adaptee.Width * Math.Sqrt(2) / 2;
            }
        }
        public double GetRadius()
        {
            return Radius;
        }

        public void SetRadius(double radius)
        {
            var width = radius / Math.Sqrt(2);
            _adaptee.SetWidth(width * 2);
        }

        public void SetAdaptee(ISquarePeg squarePeg)
        {
            _adaptee = squarePeg;
        }

        public ISquarePeg GetAdaptee()
        {
            ValidateAndThrow();
            return _adaptee;
        }

        private void ValidateAndThrow()
        {
            if (_adaptee == null)
                throw new InvalidOperationException("Adaptee is not set.");
        }

    }
}
