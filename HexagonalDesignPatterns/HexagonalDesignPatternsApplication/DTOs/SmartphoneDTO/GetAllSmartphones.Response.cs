namespace HexagonalDesignPatterns.Application.DTOs.SmartphoneDTO
{
    public class GetAllSmartphonesResponse
    {
        public IEnumerable<SmartphoneDTO>? Smartphones { get; set; }

        public class SmartphoneDTO
        {
            public int Id { get; set; }
            public required string Model { get; set; }
            public required string Manufacturer { get; set; }
            public SpecificationsDTO? Specifications { get; set; }
            public decimal Price { get; set; }
        }

        public class SpecificationsDTO
        {
            public string? ScreenSize { get; set; }
            public int BatteryLife { get; set; }
        }
    }
}
