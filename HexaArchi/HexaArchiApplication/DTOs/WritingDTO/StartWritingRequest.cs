namespace HexaArchi.Application.DTOs.WritingDTO
{
    public class StartWritingRequest
    {
        public Guid AuthorId { get; set; }
        public Guid ArticleId { get; set; }
    }
}
