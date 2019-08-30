namespace PriceCalculator
{
    public interface IExpense
    {
        string Name { get; set; }
        ExpenseType ExpenseType { get; set; }
        double Value { get; set; }
        Amount Amount { get; set; }
    }
}