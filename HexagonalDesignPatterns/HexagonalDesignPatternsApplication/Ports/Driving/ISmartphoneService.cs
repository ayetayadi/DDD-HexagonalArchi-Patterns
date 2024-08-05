using HexagonalDesignPatterns.Application.DTOs.SmartphoneDTO;

namespace HexagonalDesignPatterns.Application.Ports.Driving
{
    public interface ISmartphoneService
    {
        Task<GetAllSmartphonesResponse> GetAllAsync(int currentPage, int pageSize);
        Task<GetSmartphoneByIdResponse?> GetByIdAsync(GetSmartphoneByIdRequest request);
        Task<AddSmartphoneResponse> AddAsync(AddSmartphoneRequest request);
        Task<DeleteSmartphoneResponse> DeleteAsync(DeleteSmartphoneRequest request);
    }
}
