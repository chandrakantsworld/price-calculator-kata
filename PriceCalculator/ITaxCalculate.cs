using System;
using System.Collections.Generic;

namespace PriceCalculator
{
    interface ITaxCalculate
    {
        void CalculateTax(IProduct product, Func<IProduct, Amount> additonaldiscount);
    }

   
}