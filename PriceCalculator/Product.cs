using System;

namespace PriceCalculator
{
    class Product
    {
        public string Name { get; }
        public int Upc { get; }
        public Amount Price { get; }
       
        public Product(string name, int upc, Amount amount)
        {
            this.Name = name;
            this.Upc = upc;
            this.Price = amount;
       
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
            this.Value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
            this.Currency = new Currency("$", "USD");
        }

        public override string ToString() =>
            $"{this.Currency.CurrencySymbol}{Value:#.00}";

    }
    public class Currency
    {
        public string CurrencySymbol { get; }
        public string CurrencyCode { get; }
        public Currency(string CurrencySymbol, string CurrencyCode)
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
            if (percent < 0 || percent > 100)
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
        public double DiscountRate { get; }
        public Discount(int percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(
                    nameof(percent),
                    $"{nameof(Tax)} percentage should be in range [0..100]");

            this.Percent = percent;
            this.DiscountRate = (double)Percent / 100;
        }

        public override string ToString() => $"{Percent}%";

    }
}
