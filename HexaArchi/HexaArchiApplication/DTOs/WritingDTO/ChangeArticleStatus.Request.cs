using HexaArchi.Domain.Models;

namespace HexaArchi.Application.DTOs.WritingDTO
{
    public class ChangeArticleStatusRequest
    {
        public Guid ArticleId { get; set; }
        public WritingStatus WritingStatus { get; set; }
    }
}
