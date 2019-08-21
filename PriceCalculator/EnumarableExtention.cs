using System;
using System.Collections.Generic;

namespace PriceCalculator
{
    public static class EnumarableExtention
    {
        public static void Each<T>(
                                    this IEnumerable<T> source,
                                    Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }
    }
}
