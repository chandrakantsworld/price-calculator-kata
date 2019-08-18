namespace PriceCalculator
{
    class DiscountCalculate : ICalculate
    {
        private readonly Product product;
        public Discount Discount { get; }
        public Amount Amount { get ; set ; }

        public DiscountCalculate(Product product, Discount discount)
        {
            this.product = product ?? throw new System.ArgumentNullException(nameof(product));
            Discount = discount ?? throw new System.ArgumentNullException(nameof(discount));
        }

        

        

        public ICalculate Calculate()
        {
            this.Amount = new Amount(this.product.Price.Value * this.Discount.DiscountRate);
            return this;
        }
        public override string ToString() =>
            $"Discount {this.Discount}";
    }
}
