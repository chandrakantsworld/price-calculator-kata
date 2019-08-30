using System;

namespace PriceCalculator
{
    public class DisplayConsole : IResult
    {
        public void Display(IProduct product)
        {
            Console.WriteLine($"Product = {product.Name} UPC = {product.Upc}");
            Console.WriteLine($"Cost = {product.Price} ");
            Console.WriteLine($"Tax = {product.TotalTax}");
            if (product.TotalDiscount.Value>0)
            {
                Console.WriteLine($"Discounts  = {product.TotalDiscount}");
            }
            product.Expenses.DisplayResult();           
            Console.WriteLine($"Total = { product.FinalPrice}");            
            Console.WriteLine();
        }
    }

}