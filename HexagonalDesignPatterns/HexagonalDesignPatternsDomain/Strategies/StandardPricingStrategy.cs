using HexagonalDesignPatterns.Domain.Entities;

namespace HexagonalDesignPatterns.Domain.Strategies
{
    public class StandardPricingStrategy : IPricingStrategy
    {
        public decimal CalculatePrice(Smartphone smartphone)
        {
            return smartphone.BasePrice;
        }
    }

    public class DiscountPricingStrategy : IPricingStrategy
    {
        private readonly decimal _discountPercentage;

        public DiscountPricingStrategy(decimal discountPercentage)
        {
            _discountPercentage = discountPercentage;
        }

        public decimal CalculatePrice(Smartphone smartphone)
        {
            return smartphone.BasePrice - (smartphone.BasePrice * _discountPercentage / 100);
        }
    }

    public class PremiumPricingStrategy : IPricingStrategy
    {
        public decimal CalculatePrice(Smartphone smartphone)
        {
            return smartphone.BasePrice * 1.2m;
        }
    }
}
