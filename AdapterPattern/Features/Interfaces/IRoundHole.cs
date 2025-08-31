namespace AdapterPattern.Features.Interfaces
{
    public interface IRoundHole
    {
        double Radius { get; }
        double GetRadius();
        void SetRadius(double radius);
        bool Fits(IRoundPeg peg);
    }
}
