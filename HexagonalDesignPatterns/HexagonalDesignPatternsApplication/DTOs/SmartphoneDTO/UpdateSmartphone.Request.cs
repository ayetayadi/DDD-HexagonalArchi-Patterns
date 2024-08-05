using HexagonalDesignPatterns.Application.DTOs.SpecificationDTO;

namespace HexagonalDesignPatterns.Application.DTOs.SmartphoneDTO
{
    internal class UpdateSmartphoneRequest
    {
        public int Id { get; set; }
        public required string Model { get; set; }
        public required string Manufacturer { get; set; }
        public SpecificationsRequest? Specifications { get; set; }
        public decimal Price { get; set; }
    }
}
