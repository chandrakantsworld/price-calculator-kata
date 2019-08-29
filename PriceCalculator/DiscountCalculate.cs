using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator
{
    class DiscountCalculate : ICalculateDiscount
    {
        private readonly Discount discount;
        private readonly IEnumerable<UpcDiscounts> upcDiscounts;

        public DiscountCalculate(Discount discount, IEnumerable<UpcDiscounts> upcDiscounts)
        {
            
            this.discount = discount;
            this.upcDiscounts = upcDiscounts;
            
        }

        

        public void Calculate(IProduct product)
        {
            CalculateAddDiscount(product);
            product.Discount = this.discount;
            product.TotalDiscount = new Amount(product.FinalPrice.Value * this.discount.DiscountRate);
            
        }

        private void CalculateAddDiscount(IProduct product)
        {
            product.AddionalDiscount = new Amount(product.Price.Value * FindAddionalDiscountProduct(product).Discount.DiscountRate);
        }

        private UpcDiscounts FindAddionalDiscountProduct(IProduct s)
        {
            return this.upcDiscounts.FirstOrDefault(product => product.Upc == s.Upc) ?? new UpcDiscounts();
        }
        public override string ToString() =>
            $"Discount {this.discount}";

        public Amount CalculateAddionalDiscount(IProduct product)
        {
            var specialProduct = FindAddionalDiscountProduct(product);
            
            if (specialProduct.CanTaxCalculateAfterDiscount && specialProduct.Discount.DiscountRate > 0)
                return new Amount(product.Price.Value * specialProduct.Discount.DiscountRate);
            return new Amount(0);
            
        }
    }
}
