using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    public class Products
    {
        Tax Tax { get; set; }
        IEnumerable<UpcDiscounts> upcDiscounts = Enumerable.Empty<UpcDiscounts>();
        Discount Discount { get; set; } = new Discount(0);
        public IEnumerable<IProduct> ContainedProducts { get; }

        public Products(IEnumerable<IProduct> products)
        {
            ContainedProducts = products.ToList();
        }
        public Products CalculateTax(Tax tax) =>
           new Products(this.ContainedProducts.Select(s =>
           {
               s.TotalTax = new Amount(s.Price.Value * tax.TaxRate);
               return s;
           }));
        public Products WithTax(Tax tax)
        {
            this.Tax = tax;
            return this;
        }
        public Products WithDiscount(Discount discount)
        {
            this.Discount = discount;
            return this;
        }
        public Products WithAddionalDiscount(IEnumerable<UpcDiscounts> upcDiscounts)
        {
            this.upcDiscounts = upcDiscounts ?? Enumerable.Empty<UpcDiscounts>();
            return this;
        }
        public Products CalculateDiscount() =>
           new Products(this.ContainedProducts.Select(s =>
           {
               s.TotalDiscount = new Amount(s.Price.Value * this.Discount.DiscountRate);
               return s;
           }));
        private void CalculateAdditionalDiscount() =>
            this.upcDiscounts.Each(s =>
            {
                var specialProduct = this.ContainedProducts.FirstOrDefault(product => product.Upc == s.Upc);
                specialProduct.AddionalDiscount = new Amount(specialProduct.Price.Value * s.Discount.DiscountRate);

            });


        public void DisplayResult()
        {

            this.CalculateTax(this.Tax);
            this.CalculateDiscount();
            this.CalculateAdditionalDiscount();
            this.ContainedProducts.Each(s =>
            {
                Console.WriteLine($"Product = {s.Name} UPC = {s.Upc}");
                Console.WriteLine($"Tax = {this.Tax}, discount = {this.Discount}");
                Console.WriteLine($"Tax amount ={s.TotalTax}; Discount amount = {s.TotalDiscount} UPC discount = {s.AddionalDiscount}");
                Console.WriteLine($"Price before = {s.Price} price after = {new Amount(s.Price.Value + s.TotalTax.Value - s.TotalDiscount.Value - s.AddionalDiscount.Value)}");
                Console.WriteLine($"Total Discount = {new Amount(s.TotalDiscount.Value + s.AddionalDiscount.Value)}");
                Console.WriteLine();
            });
        }
    }
}
