using System.Collections.Generic;
using CheckoutKata.Code;

namespace CheckoutKata.Tests
{
    public class FakeDataStore
    {
        public static IEnumerable<Item> Items()
        {
            return new List<Item>
            {
                new Item{SKU = "A99", UnitPrice=.50m},
                new Item{SKU = "B15", UnitPrice=.30m},
                new Item{SKU = "C40", UnitPrice=.60m},
            };
        }
    }
}