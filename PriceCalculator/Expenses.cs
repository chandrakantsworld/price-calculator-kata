using System.Collections.Generic;

namespace PriceCalculator
{
    public class Expenses
    {

        public List<IExpense> Expense = new List<IExpense>();
        public Expenses()
        {

        }
        public Expenses(List<IExpense> Expense)
        {
            this.Expense = Expense;
        }
        public void AddExpense(IExpense expense)
        {
            this.Expense.Add(expense);
        }
        public void AddRangeExpense(IExpense expense)
        {
            this.Expense.Add(expense);
        }
        public void DisplayResult()
        {
            Expense.ForEach(exp =>
            {
                System.Console.WriteLine($"{exp.Name} = {exp.Amount}");
            });
        }
    }
}
