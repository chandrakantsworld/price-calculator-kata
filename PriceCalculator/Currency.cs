namespace PriceCalculator
{
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
}
