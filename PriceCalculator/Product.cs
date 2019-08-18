using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator
{
    public interface IProduct
    {
        string Name { get; }
        int Upc { get; }
        Amount Price { get; }
        Amount TotalTax { get; set; }
        Amount TotalDiscount { get; set; }
        Amount AddionalDiscount { get; set; } 

    }
    public static class EnumarableExtention
    {
        public static void Each<T>(
                                    this IEnumerable<T> source,
                                    Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }
    }
    public class UpcDiscounts
    {
        public int Upc { get; set; }
        public Discount Discount { get; set; }
    }
    
    class Product : IProduct
    {
        public string Name { get; }
        public int Upc { get; }
        public Amount Price { get; }
        public Amount TotalTax { get; set; }
        public Amount TotalDiscount { get; set; }
        public Amount AddionalDiscount { get; set; } = new Amount(0);

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
