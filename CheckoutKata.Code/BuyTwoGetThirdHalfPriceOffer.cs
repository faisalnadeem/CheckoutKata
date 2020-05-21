using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Code
{
    public class BuyTwoGetThirdHalfPriceOffer : IDiscountCalculator
    {
        public string SKU { get; set; }

        public bool IsApplicable(List<Item> items)
        {
            var itemCount = items.Count(x => x.SKU == SKU);
            return itemCount > 0 && (itemCount / 3 > 0 || itemCount % 3 == 0);
        }

        public decimal CalculateDiscount(List<Item> items)
        {
            var itemCount = items.Count(x => x.SKU == SKU);
            var unitPrice = items.FirstOrDefault(x => x.SKU == SKU).UnitPrice;
            var discountMultiplier = itemCount / 3;
            return discountMultiplier * (unitPrice/2);

        }
    }
}