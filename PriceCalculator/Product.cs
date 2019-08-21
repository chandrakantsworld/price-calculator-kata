using System.Linq;

namespace PriceCalculator
{

   public class Product : IProduct
    {
        public string Name { get; }
        public int Upc { get; }
        public Amount Price { get; }
        public Amount TotalTax { get; set; }
        public Amount TotalDiscount { get; set; }
        public Amount AddionalDiscount { get; set; } = new Amount(0);
        public Amount FinalPrice { get; set; } = new Amount(0);

        public Product(string name, int upc, Amount amount)
        {
            this.Name = name;
            this.Upc = upc;
            this.Price = amount;

        }



        public override string ToString() =>
            $"Product Name {this.Name} UPC {this.Upc} Price {this.Price}";
    }
}
