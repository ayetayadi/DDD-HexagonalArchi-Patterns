using HexaArchi.Application.DTOs.WritingDTO;

namespace HexaArchi.Application.Ports.Driving
{
    public interface IWritingService
    {
        Task<ChangeArticleStatusResponse> ChangeArticleStatusAsync(ChangeArticleStatusRequest request);
        Task<StartWritingResponse> StartWritingAsync(StartWritingRequest request);
    }
}
