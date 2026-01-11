
//simulate the threads producing and consuming items from the BoundedBlockingQueue

using BoundedBlockingQueue;

var queue = new BlockingQueue(5);
var producer = new Thread(() =>
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Producing {i}");
        queue.Enqueue(i);
        Console.WriteLine($"Produced {i}");
        Thread.Sleep(100); // Simulate time taken to produce an item
    }
});

var consumer = new Thread(() =>
{
    for (int i = 0; i < 10; i++)
    {
        int item = queue.Dequeue();
        Console.WriteLine($"Consumed {item}");
        Thread.Sleep(150); // Simulate time taken to consume an item
    }
});

producer.Start();
consumer.Start();
