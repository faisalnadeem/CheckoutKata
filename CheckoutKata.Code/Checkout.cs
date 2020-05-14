using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Code
{
    public class Checkout
    {
        private static readonly List<Item> Items = new List<Item>();

        public decimal Total()
        {
            return Items.Sum(x => x.UnitPrice);
        }

        public void Scan(Item item)
        {
            Items.Add(item);
        }

    }
}