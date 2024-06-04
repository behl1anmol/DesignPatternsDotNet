namespace SingletonPattern;

public sealed class Singleton
{
    private static readonly Lazy<Singleton> Lazy = new(() => new Singleton());

    public static Singleton Instance
    {
        get
        {
            Logger.Log("Creating Instance");
            return Lazy.Value;
        }
    }

    private Singleton()
    {
        Logger.Log("Constructor invoked");
    }
}