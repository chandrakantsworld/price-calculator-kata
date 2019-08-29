using System;

namespace PriceCalculator
{
    public class DisplayConsole : IResult
    {
        public void Display(IProduct s)
        {
            Console.WriteLine($"Product = {s.Name} UPC = {s.Upc}");
            Console.WriteLine($"Tax = {s.Tax}, discount = {s.Discount}");
            Console.WriteLine($"Tax amount ={s.TotalTax}; Discount amount = {s.TotalDiscount} UPC discount = {s.AddionalDiscount}");
            Console.WriteLine($"Price before = {s.Price} price after = { new Amount(s.Price.Value + s.TotalTax.Value - s.TotalDiscount.Value - s.AddionalDiscount.Value)}");
            Console.WriteLine($"Total Discount = {new Amount(s.TotalDiscount.Value + s.AddionalDiscount.Value)}");
            Console.WriteLine();
        }
    }

}