namespace PriceCalculator
{
    class TaxCalculate : ITaxCalculate
    {
        public Product product { get; }
        public Tax tax { get; }

        public Amount Amount  { get; set; }

        public TaxCalculate(Product product, Tax tax)
        {
            this.product = product ?? throw new System.ArgumentNullException(nameof(product));
            this.tax = tax ?? throw new System.ArgumentNullException(nameof(tax));
        }
        public ITaxCalculate WithTaxCalculate() {

          this.Amount = new Amount(this.product.Price.Value * this.tax.TaxRate);

            return this;
        }
        public override string ToString() =>
            $"Tax = {this.tax}";
    }
}
