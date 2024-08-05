using HexagonalDesignPatterns.Application.DTOs.SpecificationDTO;

namespace HexagonalDesignPatterns.Application.DTOs.SmartphoneDTO
{
    public class AddSmartphoneRequest
    {
        public required string Model { get; set; }
        public  required string Manufacturer { get; set; }
        public SpecificationsRequest? Specifications { get; set; }
        public decimal BasePrice { get; set; }
        public required string PricingStrategyType { get; set; }
    }
}
