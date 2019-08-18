using System;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {


            Product product = new Product("The Little Prince", 12345, new Amount(20.25));
            var calculateTax = new TaxCalculate(product, new Tax(20)).Calculate();
            var calculateDiscount = new DiscountCalculate(product, new Discount(15)).Calculate();

            Console.WriteLine($"Tax = {calculateTax} Discount = {calculateDiscount}");
            Console.WriteLine($"Tax amount ={calculateTax.Amount}; Discount amount = {calculateDiscount.Amount}");
            Console.WriteLine($"Price before = {product.Price} price after = {product.Price.Value + calculateTax.Amount.Value - calculateDiscount.Amount.Value}");

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //  Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
