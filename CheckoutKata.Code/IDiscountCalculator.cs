using System.Collections.Generic;

namespace CheckoutKata.Code
{
    public interface IDiscountCalculator
    {
        bool IsApplicable(List<Item> items);
        decimal CalculateDiscount(List<Item> items);
    }
}