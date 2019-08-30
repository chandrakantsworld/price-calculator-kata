using PriceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PriceCalculatorTests
{
   public class ApplyExpenseOnProduct
    {
        public static readonly List<object[]> ProductTestData = new List<object[]>
               {
                  new object[]{ new Product("The Little Prince", 12345, new Amount(20.25)),  21,15,
                      new List<UpcDiscounts>() { new UpcDiscounts() { Upc = 12345, Discount = new Discount(7) } },"$4.25", "$4.46", "$22.44","$0.20","$2.20",
                      new Expenses(new List<IExpense>(){(new Expense()
                {
                    Name = "Packaging",
                    ExpenseType = ExpenseType.Percentage,
                    Value = 1
                }),
                         new Expense()
                {
                    Name = "Transport",
                    ExpenseType = ExpenseType.Monetary,
                    Value = 2.2
                }
                  }) }
               };
        [Theory]
        [MemberData("ProductTestData")]
        public void Apply_Expense_Discount_ExpectedResult(Product product,
           int tax, int discount, List<UpcDiscounts> upcDiscounts, string expectedTax,
               string expectedDiscount, string expectedPrice, string packaging,string shipping,Expenses expenses)
        {
            //Arrange
            Products products = new Products(new[] { product });
            products.WithTax(new Tax(tax))
                .WithDiscount(new Discount(discount), upcDiscounts)
                .WithExpense(expenses);

            //Act
            products.DisplayResult();

            //Assert
            Assert.Equal(expectedTax, products.ContainedProducts.FirstOrDefault().TotalTax.ToString());
            Assert.Equal(packaging, products.ContainedProducts.FirstOrDefault().Expenses.Expense.FirstOrDefault(s=>s.Name== "Packaging").Amount.ToString());
            Assert.Equal(shipping, products.ContainedProducts.FirstOrDefault().Expenses.Expense.FirstOrDefault(s => s.Name == "Transport").Amount.ToString());
            Assert.Equal(expectedDiscount, products.ContainedProducts.FirstOrDefault().TotalDiscount.ToString());
            Assert.Equal(expectedPrice, products.ContainedProducts.FirstOrDefault().FinalPrice.ToString());
        }
    }
}
