﻿using HexaArchi.Domain.Models;

namespace HexaArchi.Application.DTOs.ArticleDTO
{
    public class GetAllArticleResponse
    {
        public IEnumerable<ArticleDto>? Articles { get; set; }

    }
    public class ArticleDto
    {
        public Guid ArticleId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public WritingStatus WritingStatus { get; set; }
        public Guid? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
