namespace PriceCalculator
{
    public class Expense : IExpense
    {
        public string Name { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public double Value { get; set; }
        public Amount Amount { get; set; }

    }
}
