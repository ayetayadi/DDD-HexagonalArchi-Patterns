using BookFetcher.Application.Ports.Driven;
using BookFetcher.Domain.Models;
using BookFetcher.Application.Ports.Driving;
using BookFetcher.SharedKarnel.Models;
using BookFetcher.Application.DTOs.BookDTO;

namespace BookFetcher.Application.Services
{
    public class BookService : IBookService
    {
        #region Variables + Constructor
        private readonly IBookRepository _bookRepository;
        private readonly IBookFactory _bookFactory;

        public BookService(IBookRepository bookRepository, IBookFactory bookFactory)
        {
            _bookRepository = bookRepository;
            _bookFactory = bookFactory;
        }
        #endregion

        #region Get All
        public async Task<GetAllBookResponse> GetAllAsync(int currentPage, int pageSize)
        {
            int totalCount = await _bookRepository.GetTotalCountAsync();

            IEnumerable<Book> books = await _bookRepository.GetAllAsync(currentPage, pageSize);

            IEnumerable<BookDto> bookDtos = books.Select(book => new BookDto
            {
                BookId = book.Id,
                Title = book.Title,
                Author = book.Author,
            });

            PagedList<BookDto> pagedList = new PagedList<BookDto>(
                bookDtos.ToList(),
                totalCount,
                currentPage,
                pageSize
            );

            return new GetAllBookResponse
            {
                Books = pagedList
            };
        }
        #endregion

        #region Get by ID
        public async Task<GetBookByIdResponse?> GetByIdAsync(GetBookByIdRequest request)
        {
            Book? book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                return null;
            }

            return new GetBookByIdResponse
            {
                Title = book.Title,
                Author = book.Author,
            };
        }
        #endregion

        #region Add
        public async Task<PostBookResponse> AddAsync(PostBookRequest request)
        {
            Book book = _bookFactory.CreateBook(request);
            await _bookRepository.AddAsync(book);
            return _bookFactory.CreatePostBookResponse(book);
        }
        #endregion

        #region Delete 
        public async Task<DeleteBookResponse> DeleteAsync(DeleteBookRequest request)
        {
            Book? book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                return new DeleteBookResponse { Success = false };
            }

            await _bookRepository.DeleteAsync(request.BookId);
            return new DeleteBookResponse { Success = true };
        }
        #endregion
    }
}
