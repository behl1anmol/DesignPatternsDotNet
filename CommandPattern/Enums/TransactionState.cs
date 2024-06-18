using System.ComponentModel;

namespace CommandPattern.Enums;

public enum TransactionState
{
    [Description("New TransactionEntity")]
    New,
    [Description("TransactionEntity Open")]
    Open,
    [Description("TransactionEntity Closed")]
    Closed
}