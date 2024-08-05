using HexagonalDesignPatterns.Domain.Strategies;

namespace HexagonalDesignPatterns.Domain.Factories
{
    public interface IPricingStrategyFactory
    {
        IPricingStrategy CreateStrategy(string strategyType);
    }
}
