namespace PriceCalculator
{
    interface ICalculateDiscount
    {
        void Calculate(IProduct product);
        Amount CalculateAddionalDiscount(IProduct product);
    }

}