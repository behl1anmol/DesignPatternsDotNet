using AdapterPattern.Features.Interfaces;

namespace AdapterPattern.Features
{
    public class SquarePeg : ISquarePeg
    {
        private double _width;
        public SquarePeg() { }

        public double Width
        {
            get { return _width; }
            private set { _width = value; }
        }

        public double GetWidth() => Width;

        public void SetWidth(double width)
        {
            Width = width;
        }
    }
}
