using AdapterPattern.Features.Interfaces;

namespace AdapterPattern.Features.Adapter
{
    public interface ISquarePegAdapter : IRoundPeg
    {
        public void SetAdaptee(ISquarePeg squarePeg);
        public ISquarePeg GetAdaptee();
    }
}
