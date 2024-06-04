using System.Collections.Concurrent;

namespace SingletonPattern;

public static class Logger
{
    private static readonly ConcurrentQueue<string> _log = new();
    public static int DelayMilliseconds { get; set; } = 0;

    public static void Log(string message)
    {
        Thread.Sleep(DelayMilliseconds);
        _log.Enqueue(message);
    }

    public static void Clear()
    {
        _log.Clear();
    }

    public static string Dump()
    {
        return string.Join(Environment.NewLine, _log);
    }

    public static List<string> Output()
    {
        return _log.ToList();
    }
}