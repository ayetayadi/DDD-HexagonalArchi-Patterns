using AutoMapper;
using HexaArchi.Application.DTOs.AuthorDTO;
using HexaArchi.Application.Ports.Driven;
using HexaArchi.Application.Ports.Driving;
using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Services
{
    public class AuthorService : IAuthorService
    {
        #region Variables + Constructor

        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        #endregion

        #region GetAll

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            IEnumerable<Author> authors = await _authorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        #endregion

        #region GetById

        public async Task<GetAuthorByIdResponse?> GetByIdAsync(GetAuthorByIdRequest request)
        {
            Author? author = await _authorRepository.GetByIdAsync(request.AuthorId);
            return author == null ? null : _mapper.Map<GetAuthorByIdResponse>(author);
        }

        #endregion

        #region Add

        public async Task<PostAuthorResponse> AddAsync(PostAuthorRequest request)
        {
            Author author = _mapper.Map<Author>(request);
            await _authorRepository.AddAsync(author);
            return _mapper.Map<PostAuthorResponse>(author);
        }

        #endregion

        #region Update

        public async Task<PutAuthorResponse> UpdateAsync(Guid id, PutAuthorRequest request)
        {
            Author? existingAuthor = await _authorRepository.GetByIdAsync(id);

            if (existingAuthor == null)
            {
                return new PutAuthorResponse { Success = false };
            }

            Author authorToUpdate = _mapper.Map<Author>(request);
            await _authorRepository.UpdateAsync(id, authorToUpdate);

            return new PutAuthorResponse { Success = true };
        }

        #endregion

        #region Delete

        public async Task<DeleteAuthorResponse> DeleteAsync(DeleteAuthorRequest request)
        {
            Author? author = await _authorRepository.GetByIdAsync(request.AuthorId);
            if (author == null)
            {
                return new DeleteAuthorResponse { Success = false };
            }

            await _authorRepository.DeleteAsync(request.AuthorId);
            return new DeleteAuthorResponse { Success = true };
        }

        #endregion
    }
}
