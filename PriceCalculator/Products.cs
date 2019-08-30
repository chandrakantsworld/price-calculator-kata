using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator
{
    public class Products
    {
       
        public IEnumerable<IProduct> ContainedProducts { get; }
        public IEnumerable<UpcDiscounts> UpcDiscounts { get; set; } = Enumerable.Empty<UpcDiscounts>();

        private ITaxCalculate taxCalculate;
        private ICalculateDiscount calculateDiscount;
        private ICalculateExpense calculateExpense;
        public Expenses Expenses { get; set; } 
        private readonly IResult result;
        public Products(IEnumerable<IProduct> products)
        {
            ContainedProducts = products.ToList();
            this.calculateDiscount =  new DiscountCalculate(new Discount(0)
            , Enumerable.Empty<UpcDiscounts>());
            result = new DisplayConsole();
            calculateExpense = new ExpenseCalculator(new Expenses());
        }

        public Products WithTax(Tax tax)
        {
            
            this.taxCalculate = new TaxCalculate(tax);
            return this;
        }
        public Products WithDiscount(Discount discount, IEnumerable<UpcDiscounts> upcDiscounts = null)
        {
            
            this.UpcDiscounts = upcDiscounts ?? Enumerable.Empty<UpcDiscounts>();
            this.calculateDiscount = new DiscountCalculate(discount, this.UpcDiscounts);
            return this;
        }
        public Products WithExpense(Expenses expenses)
        {
            this.Expenses = expenses;
            this.calculateExpense = new ExpenseCalculator(this.Expenses);
            return this;
        }


        public void DisplayResult()
        {

            this.ContainedProducts.Each(s =>
            {
                taxCalculate.CalculateTax(s, this.calculateDiscount.CalculateAddionalDiscount);
                this.calculateDiscount?.Calculate(s);
                
                s.FinalPrice = new Amount(s.Price.Value + s.TotalTax.Value - s.TotalDiscount.Value - s.AddionalDiscount.Value);
                s.TotalDiscount = new Amount(s.TotalDiscount.Value + s.AddionalDiscount.Value);
                this.calculateExpense.Calculate(s);
                result.Display(s);
            });
        }
    }
}
