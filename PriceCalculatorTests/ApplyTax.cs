using PriceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PriceCalculatorTests
{
   public class ApplyTax
    {
        [Theory]
        [InlineData(20, "$24.30")]
        [InlineData(21, "$24.50")]
        public void Step1_Tax_ExpectedResult(int percent, string expectedResult)
        {
            //Arrange
            Products products = new Products(new[] { new Product("The Little Prince", 12345, new Amount(20.25)) { } });
            products.WithTax(new Tax(percent));

            //Act
            products.DisplayResult();

            //Assert
            Assert.Equal(expectedResult, products.ContainedProducts.FirstOrDefault().FinalPrice.ToString());
        }
    }
}
