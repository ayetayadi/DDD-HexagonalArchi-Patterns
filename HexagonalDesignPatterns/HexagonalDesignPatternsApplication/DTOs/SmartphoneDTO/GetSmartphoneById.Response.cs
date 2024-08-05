using HexagonalDesignPatterns.Application.DTOs.SpecificationDTO;

namespace HexagonalDesignPatterns.Application.DTOs.SmartphoneDTO
{
    public class GetSmartphoneByIdResponse
    {
        public int Id { get; set; }
        public required string Model { get; set; }
        public required string Manufacturer { get; set; }
        public SpecificationsResponse? Specifications { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
    }
}
