using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    class Product
    {
        public string Name { get; }
        public int Upc { get; }
        public Amount Price { get;  }
        public Tax Tax { get;  }
        public Product(string name,int upc,Amount amount,Tax tax)
        {
            this.Name = name;
            this.Upc = upc;
            this.Price = amount;
            this.Tax = tax;
        }
        public string CalculateTax()
        {          
          var  PriceAfterTaxes = new Amount(this.Price.Value + (this.Price.Value * this.Tax.TaxRate));
            return $"Product price reported as {this.Price} before tax and {PriceAfterTaxes} after {this.Tax} tax.";
        }
        public override string ToString() =>
            $"Product Name {this.Name} UPC {this.Upc} Price {this.Price}";
    }

    public class Amount
    {
        public Currency Currency { get; set; }
        public double Value { get; }
        public Amount(double value)
        {
            if (value < 0) throw new ArgumentException("Amount can not be less than 0");
            this.Value =  Math.Round(value, 2, MidpointRounding.AwayFromZero);
            this.Currency = new Currency("$", "USD");
        }

        public override string ToString() =>
            $"{this.Currency.CurrencySymbol}{Value:#.00}";

    }
    public class Currency
    {
        public string CurrencySymbol { get;  }
        public string CurrencyCode { get; }
        public Currency(string CurrencySymbol,string CurrencyCode)
        {
            this.CurrencyCode = CurrencyCode;
            this.CurrencySymbol = CurrencySymbol;
        }
    }
    public class Tax
    {
        private readonly int Percent;
        public double TaxRate { get; }
        public Tax(int percent)
        {
            if(percent<0 || percent>100)
                throw new ArgumentOutOfRangeException(
                    nameof(percent),
                    $"{nameof(Tax)} percentage should be < 0 and > 100");

            this.Percent = percent;
            TaxRate = (double)Percent / 100;
        }

        public override string ToString() => $"{Percent}%";

    }
    public class Discount
    {
        private readonly int Percent;

        public Discount(int percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(
                    nameof(percent),
                    $"{nameof(Tax)} percentage should be in range [0..100]");

            this.Percent = percent;
        }

        public override string ToString() => $"{Percent}";

    }
}
