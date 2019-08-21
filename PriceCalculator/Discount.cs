using System;

namespace PriceCalculator
{
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
