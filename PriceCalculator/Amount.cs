using System;

namespace PriceCalculator
{
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
            $"{this.Currency.CurrencySymbol}{Value:#0.00}";

    }
}
