namespace HexaArchi.Application.DTOs.AuthorDTO
{
    public class PutAuthorRequest
    {
        public required string Name { get; set; }
        public double Balance { get; set; }
    }
}
