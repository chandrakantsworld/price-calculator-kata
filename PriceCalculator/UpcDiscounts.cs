namespace PriceCalculator
{
    public class UpcDiscounts
    {
        public bool CanTaxCalculateAfterDiscount { get; set; } = false;
        public int Upc { get; set; }
        public Discount Discount { get; set; } = new Discount(0);
    }
}
