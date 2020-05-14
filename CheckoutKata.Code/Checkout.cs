using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Code
{
    public class Checkout
    {
        private readonly List<Item> Items = new List<Item>();

        public decimal Total()
        {
            if (!Items.Any()) return 0M;

            return Items.Sum(x => x.UnitPrice);
        }

        public void Scan(Item item)
        {
            if (item == null) return;

            Items.Add(item);
        }

    }
}