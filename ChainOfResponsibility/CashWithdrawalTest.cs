using ChainOfResponsibility.CashWithdrawal;

namespace ChainOfResponsibility;

[TestFixture]
public class CashWithdrawalTest
{
    private CashWithdrawalProcessor _atmProcessor;
    private StringWriter _sw;
    
    [SetUp]
    public void Setup()
    {
        _sw.GetStringBuilder().Clear();
        _atmProcessor = new ThousandRupeeProcessor(
            new FiveHundredRupeeProcessor(
                new HundredRupeeProcessor(null, 800m), 2000m), 6000m);
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _sw = new StringWriter();
        Console.SetOut(_sw);
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        var originalOut = Console.Out;
        Console.SetOut(originalOut);
        _sw.Close();
        _sw.Dispose();
    }

    [Test]
    public void CashWithdrawal_WithdrawalSuccessful()
    {
        var amountToWithdraw = 3700m;
        _atmProcessor.ProcessWithdrawal(amountToWithdraw);
        var output = _sw.ToString().Trim();
        var expected = string.Join(Environment.NewLine, new[]
        {
            "Dispensed 3 notes of 1000. Remaining amount to dispense: 700",
            "Dispensed 1 notes of 500. Remaining amount to dispense: 200",
            "Dispensed 2 notes of 100. Remaining amount to dispense: 0",
            "Dispensed amount with available denominations."
        }).Trim();
        Assert.That(output, Is.EqualTo(expected));
    }

    [Test]
    public void CashWithdrawal_InsufficientDenominations()
    {
        var amountToWithdraw = 9900m;
        _atmProcessor.ProcessWithdrawal(amountToWithdraw);
        var output = _sw.ToString().Trim();
        var expected = string.Join(Environment.NewLine, new[]
        {
            "Dispensed 6 notes of 1000. Remaining amount to dispense: 3900",
            "Dispensed 4 notes of 500. Remaining amount to dispense: 1900",
            "Dispensed 8 notes of 100. Remaining amount to dispense: 1100",
            "Cannot process the requested amount with available denominations."
        }).Trim();
        Assert.That(output, Is.EqualTo(expected));
    }

    [Test]
    public void CashWithdrawal_ExactDenominationsUnavailable()
    {
        var amountToWithdraw = 1250m;
        _atmProcessor.ProcessWithdrawal(amountToWithdraw);
        var output = _sw.ToString().Trim();
        var expected = string.Join(Environment.NewLine, new[]
        {
            "Dispensed 1 notes of 1000. Remaining amount to dispense: 250",
            "Dispensed 2 notes of 100. Remaining amount to dispense: 50",
            "Cannot process the requested amount with available denominations."
        }).Trim();
        Assert.That(output, Is.EqualTo(expected));
    }
    
    [Test]
    public void CashWithdrawal_ZeroAmount()
    {
        var amountToWithdraw = 0m;
        _atmProcessor.ProcessWithdrawal(amountToWithdraw);
        var output = _sw.ToString().Trim();
        var expected = string.Join(Environment.NewLine, new[]
        {
            "Dispensed amount with available denominations."
        }).Trim();
        Assert.That(output, Is.EqualTo(expected));
    }
}