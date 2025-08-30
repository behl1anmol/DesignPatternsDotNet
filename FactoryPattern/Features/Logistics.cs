namespace FactoryPattern.Features
{
    internal abstract class Logistics<T> where T : class, ILogistics
    {
        public virtual string Message
        {
            get;
            set;
        } = "This is Base Logistics";
        public virtual string GetInfo()
        {
            return $"Base Logistics feature invoked with message: {this.Message}";
        }
    }
}
