using HexagonalDesignPatterns.Domain.Strategies;

namespace HexagonalDesignPatterns.Domain.Factories
{
    public class PricingStrategyFactory : IPricingStrategyFactory
    {
        public IPricingStrategy CreateStrategy(string strategyType)
        {
            return strategyType.ToLower() switch
            {
                "standard" => new StandardPricingStrategy(),
                "discount" => new DiscountPricingStrategy(10),
                "premium" => new PremiumPricingStrategy(),
                _ => throw new ArgumentException("Invalid pricing strategy type", nameof(strategyType))
            };
        }
    }
}
