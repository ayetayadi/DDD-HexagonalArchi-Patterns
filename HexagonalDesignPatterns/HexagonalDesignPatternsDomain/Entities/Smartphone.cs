using HexagonalDesignPatterns.Domain.Strategies;

namespace HexagonalDesignPatterns.Domain.Entities
{
    public class Smartphone
    {
        public int Id { get; set; }
        public required string Model { get; set; }
        public required string Manufacturer { get; set; }
        public Specifications? Specifications { get; set; }
        public decimal BasePrice { get; set; }
        public IPricingStrategy? PricingStrategy { get; set; }
        public decimal GetPrice()
        {
            return PricingStrategy.CalculatePrice(this);
        }
    }

}
