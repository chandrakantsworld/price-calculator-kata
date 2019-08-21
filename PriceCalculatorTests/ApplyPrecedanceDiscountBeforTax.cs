using PriceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PriceCalculatorTests
{
   public class ApplyPrecedanceDiscountBeforTax
    {
        public static readonly List<object[]> ProductTestData = new List<object[]>
               {
                  new object[]{ new Product("The Little Prince", 12345, new Amount(20.25)),  20,15,
                      new List<UpcDiscounts>() { new UpcDiscounts() { Upc = 12345, Discount = new Discount(7),CanTaxCalculateAfterDiscount = true } },"$3.77", "$2.82", "$19.78","$1.42"},
                  new object[]{ new Product("The Little Prince", 789, new Amount(20.25)),  21,15,
                      new List<UpcDiscounts>() { new UpcDiscounts() { Upc = 12345, Discount = new Discount(7) } },"$4.25", "$3.04", "$21.46","$.00"},
               };
        [Theory]
        [MemberData("ProductTestData")]
        public void Apply_Precedance_Discount_ExpectedResult(Product product,
           int tax, int discount, List<UpcDiscounts> upcDiscounts, string expectedTax,
               string expectedDiscount, string expectedPrice, string expectedAddionalDiscount)
        {
            //Arrange
            Products products = new Products(new[] { product });
            products.WithTax(new Tax(tax))
                .WithDiscount(new Discount(discount))
                .WithAddionalDiscount(upcDiscounts);

            //Act
            products.DisplayResult();

            //Assert
            Assert.Equal(expectedTax, products.ContainedProducts.FirstOrDefault().TotalTax.ToString());
            Assert.Equal(expectedAddionalDiscount, products.ContainedProducts.FirstOrDefault().AddionalDiscount.ToString());
            Assert.Equal(expectedDiscount, products.ContainedProducts.FirstOrDefault().TotalDiscount.ToString());
            Assert.Equal(expectedPrice, products.ContainedProducts.FirstOrDefault().FinalPrice.ToString());
        }
    }
}
