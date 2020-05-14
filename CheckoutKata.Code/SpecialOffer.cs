using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKata.Code
{
    public interface IDiscountCalculator
    {
        bool IsApplicable(List<Item> items);
        decimal CalculateDiscount(List<Item> items);
    }

    public class SpecialOffer : IDiscountCalculator
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal OfferPrice { get; set; }

        public bool IsApplicable(List<Item> items)
        {
            var itemCount = items.Count(x => x.SKU == SKU);
            return itemCount > 0 && (itemCount / Quantity > 0 || itemCount % Quantity == 0);
        }

        public decimal CalculateDiscount(List<Item> items)
        {
            var itemCount = items.Count(x => x.SKU == SKU);
            var discountMultiplier = itemCount / Quantity;
            var actualPriceForEligibleItems = discountMultiplier * Quantity * items.FirstOrDefault(x => x.SKU == SKU).UnitPrice;
            return actualPriceForEligibleItems - discountMultiplier * OfferPrice;

        }
    }
}
