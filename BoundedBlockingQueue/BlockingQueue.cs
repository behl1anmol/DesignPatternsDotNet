namespace BoundedBlockingQueue;

public class BlockingQueue
{
    private int _capacity;
    private readonly SemaphoreSlim _s1;
    private readonly SemaphoreSlim _s2;
    private Queue<int> _queue;
    public BlockingQueue(int capacity)
    {
        _capacity = capacity;
        _s1 = new SemaphoreSlim(capacity, capacity);
        _s2 = new SemaphoreSlim(0, capacity);
        _queue = new Queue<int>();
    }

    public void Enqueue(int element)
    {
        _s1.Wait();
        _queue.Enqueue(element);
        _s2.Release();
        
    }
    
    public int Dequeue()
    {
        _s2.Wait();
        int element = _queue.Dequeue();
        _s1.Release();
        return element;
    }
    
    public int Size()
    {
        return _queue.Count;
    }
}