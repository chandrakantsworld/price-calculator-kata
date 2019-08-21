using System;

namespace PriceCalculator
{
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
}
