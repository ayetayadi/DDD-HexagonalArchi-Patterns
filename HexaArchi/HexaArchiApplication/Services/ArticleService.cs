using AutoMapper;
using HexaArchi.Application.DTOs.ArticleDTO;
using HexaArchi.Application.DTOs.AuthorDTO;
using HexaArchi.Application.Ports.Driven;
using HexaArchi.Application.Ports.Driving;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Services
{
    public class ArticleService : IArticleService
    {
        #region Variables + Constructor

        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        #endregion

        #region Get All

        public async Task<IEnumerable<ArticleDto>> GetAllAsync()
        {
            IEnumerable<Article> articles = await _articleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }

        #endregion

        #region Get By ID
        public async Task<GetArticleByIdResponse?> GetByIdAsync(GetArticleByIdRequest request)
        {
            Article? article = await _articleRepository.GetByIdAsync(request.ArticleId);
            return article == null ? null : _mapper.Map<GetArticleByIdResponse>(article);
        }

        #endregion

        #region Add
        public async Task<PostArticleResponse> AddAsync(PostArticleRequest request)
        {
            Article article = _mapper.Map<Article>(request);
            await _articleRepository.AddAsync(article);
            return _mapper.Map<PostArticleResponse>(article);
        }

        #endregion

        #region Update

        public async Task<PutArticleResponse> UpdateAsync(Guid id, PutArticleRequest request)
        {
            Article? existingArticle = await _articleRepository.GetByIdAsync(id);

            if (existingArticle == null)
            {
                return new PutArticleResponse { Success = false };
            }

            Article articleToUpdate = _mapper.Map<Article>(request);
            await _articleRepository.UpdateAsync(id, articleToUpdate);

            return new PutArticleResponse { Success = true };
        }

        #endregion

        #region Delete
        public async Task<DeleteArticleResponse> DeleteAsync(DeleteArticleRequest request)
        {
            Article? article = await _articleRepository.GetByIdAsync(request.ArticleId);
            if (article == null)
            {
                return new DeleteArticleResponse { Success = false };
            }

            await _articleRepository.DeleteAsync(request.ArticleId);
            return new DeleteArticleResponse { Success = true };
        }

        #endregion
    }
}
