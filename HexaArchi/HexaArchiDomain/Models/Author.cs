using HexaArchi.SharedKarnel.Entities;

namespace HexaArchi.Domain.Models
{
    public class Author : BaseEntity
    {
        public required string Name { get; set; }
        public double Balance { get; set; }
        public ICollection<Article>? Articles { get; set; }

    }
}
