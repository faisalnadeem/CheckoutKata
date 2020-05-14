using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Code
{
    public class Checkout
    {
        private readonly List<Item> _items;
        private readonly IEnumerable<IDiscountCalculator> _discountCalculators;

        public Checkout()
        {
            _items = new List<Item>();
            _discountCalculators = AvailableSpecialOffers(); //todo: get all using DI
        }

        public decimal Total()
        {
            if (!_items.Any()) return 0M;

            var total = _items.Sum(x => x.UnitPrice);
            var discount = 0m;

            foreach (var discountCalculator in _discountCalculators)
            {
                if (!discountCalculator.IsApplicable(_items)) continue;

                discount += discountCalculator.CalculateDiscount(_items);
            }

            return total - discount;
        }

        public void Scan(Item item)
        {
            if (item == null) return;
            _items.Add(item);
        }

        public IEnumerable<IDiscountCalculator> AvailableSpecialOffers()
        {
            yield return new SpecialOffer { SKU = "A99", Quantity = 3, OfferPrice = 1.30m };
            yield return new SpecialOffer { SKU = "B15", Quantity = 2, OfferPrice = .45m };
        }

    }
}