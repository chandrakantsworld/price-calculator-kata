using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    class PriceCalculator : ITaxCalculate, IDiscountCalculate
    {
        
        
        public IDiscountCalculate WithDiscountCalculate()
        {
            throw new NotImplementedException();
        }

        public ITaxCalculate WithTaxCalculate()
        {
            throw new NotImplementedException();
        }
    }
}
