using AutoMapper;
using HexaArchi.Application.DTOs.WritingDTO;
using HexaArchi.Application.Ports.Driven;
using HexaArchi.Application.Ports.Driving;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Services
{
    public class WritingService : IWritingService
    {
        #region Variables + Constructor

        private readonly IAuthorRepository _authorRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public WritingService(IAuthorRepository authorRepository, IArticleRepository articleRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        #endregion

        #region Change Article Status
        public async Task<ChangeArticleStatusResponse> ChangeArticleStatusAsync(ChangeArticleStatusRequest request)
        {
            Article? article = await _articleRepository.GetByIdAsync(request.ArticleId);
            if (article == null)
            {
                return new ChangeArticleStatusResponse
                {
                    Success = false,
                    Message = "Article not found!!!"
                };
            }

            article.WritingStatus = request.WritingStatus;
            await _articleRepository.UpdateAsync(article.Id, article);

            return new ChangeArticleStatusResponse
            {
                Success = true,
                Message = "Article status updated successfully"
            };
        }

        #endregion

        #region Start Writing

        public async Task<StartWritingResponse> StartWritingAsync(StartWritingRequest request)
        {
            Author? author = await _authorRepository.GetByIdAsync(request.AuthorId);
            if (author == null)
            {
                return new StartWritingResponse
                {
                    Success = false,
                    Message = "Author not found!!!"
                };
            }

            Article? article = await _articleRepository.GetByIdAsync(request.ArticleId);
            if (article == null)
            {
                return new StartWritingResponse
                {
                    Success = false,
                    Message = "Article not found!!!"
                };
            }

            article.AuthorId = author.Id;
            article.WritingStatus = WritingStatus.Writing;
            await _articleRepository.UpdateAsync(article.Id, article);

            return new StartWritingResponse
            {
                Success = true,
                Message = "Writing process started successfully"
            };
        }

        #endregion
    }
}
