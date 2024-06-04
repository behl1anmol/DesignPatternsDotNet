using SingletonPattern.TestUtils;

namespace SingletonPattern;

/*
 * Test Ordering should be avoided, test cases should be executed randomly to cover all dependencies and scenarios.
 * However, in this case, we do not have any specific dependency and therefore run test cases in a specific order.
 * A delay has been added to simulate a real-world scenario.
 */
[TestCaseOrderer("SingletonPattern.TestUtils.TestPriorityOrderer", "SingletonPattern")]
public class SingletonTest
{
    private readonly ITestOutputHelper _output;

    public SingletonTest(ITestOutputHelper output)
    {
        _output = output;
        Logger.Clear();
    }

    [Fact, TestPriority(3)]
    public void ReturnsNonNullSingletonInstance()
    {
        var result = Singleton.Instance;

        Assert.NotNull(result);
        Assert.IsType<Singleton>(result);

        Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
    }

    [Fact, TestPriority(1)]
    public void CallsTwoInstanceConstructorInvokedOnce()
    {
        Logger.DelayMilliseconds = 5;

        var instanceA = Singleton.Instance;
        Thread.Sleep(5);
        var instanceB = Singleton.Instance;

        Assert.Equal(1, Logger.Output().Count(l => l.Contains("Constructor")));
        Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
    }

    [Fact, TestPriority(2)]
    public void CallsThreeInstancesLogsThreeInstance()
    {
        Logger.DelayMilliseconds = 5;

        var instanceA = Singleton.Instance;
        Thread.Sleep(5);
        var instanceB = Singleton.Instance;
        Thread.Sleep(5);
        var instanceC = Singleton.Instance;

        Assert.Equal(3, Logger.Output().Count(l => l.Contains("Instance")));
        Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
    }
    
    [Fact, TestPriority(4)]
    public void CallsTwoInstancesReturnSameInstance()
    {
        Logger.DelayMilliseconds = 5;
        Thread.Sleep(5);
        var instanceA = Singleton.Instance;
        Thread.Sleep(5);
        var instanceB = Singleton.Instance;

        Assert.Same(instanceA, instanceB);
    }
}