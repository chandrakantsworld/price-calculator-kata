namespace PriceCalculator
{
    public class ExpenseCalculator : ICalculateExpense
    {
        private readonly Expenses expenses;

        public ExpenseCalculator(Expenses expenses)
        {
            this.expenses = expenses;
        }

        public void Calculate(IProduct product)
        {
            this.expenses.Expense.ForEach(expense =>
            {
                expense.Amount = expense.ExpenseType == ExpenseType.Percentage
            ? new Amount(expense.Value * product.Price.Value/100)
            : new Amount(expense.Value);
                product.Expenses.AddExpense(expense);
                product.FinalPrice = new Amount(product.FinalPrice.Value + expense.Amount.Value);
            });
        }
    }
}
