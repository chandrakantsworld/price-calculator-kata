namespace PriceCalculator
{
    public interface IProduct
    {
        string Name { get; }
        int Upc { get; }
        Amount Price { get; }
        Amount TotalTax { get; set; }
        Amount FinalPrice { get; set; }
        Amount TotalDiscount { get; set; }
        Amount AddionalDiscount { get; set; } 
        Tax Tax { get; set; }
        Discount Discount { get; set; }

    }
}
