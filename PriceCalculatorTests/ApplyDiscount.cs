using PriceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PriceCalculatorTests
{
   public class ApplyDiscount
    {
        
        public static readonly List<object[]> ProductTestData = new List<object[]>
               {
                  new object[]{ new Product("The Little Prince", 12345, new Amount(20.25)),  20,15, "$4.05", "$3.04", "$21.26"},
                  
               };
        [Theory]
        [MemberData("ProductTestData")]        
        public void Apply_Discount_ExpectedResult(Product product,
            int tax,int discount,string expectedTax,
                string expectedDiscount,string expectedPrice)
        {
            //Arrange
            Products products = new Products(new[] { product });
            products.WithTax(new Tax(tax));
            products.WithDiscount(new Discount(discount));

            //Act
            products.DisplayResult();

            //Assert
            Assert.Equal(expectedTax, products.ContainedProducts.FirstOrDefault().TotalTax.ToString());
            Assert.Equal(expectedDiscount, products.ContainedProducts.FirstOrDefault().TotalDiscount.ToString());
            Assert.Equal(expectedPrice, products.ContainedProducts.FirstOrDefault().FinalPrice.ToString());
        }
    }
}
