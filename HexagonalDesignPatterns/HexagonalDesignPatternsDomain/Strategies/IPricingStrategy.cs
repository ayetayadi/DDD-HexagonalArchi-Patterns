using HexagonalDesignPatterns.Domain.Entities;

namespace HexagonalDesignPatterns.Domain.Strategies
{
    public interface IPricingStrategy
    {
        decimal CalculatePrice(Smartphone smartphone);
    }
}
