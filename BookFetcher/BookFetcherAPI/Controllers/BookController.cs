using Microsoft.AspNetCore.Mvc;
using BookFetcher.Application.Ports.Driving;
using System.Threading.Tasks;
using System;
using BookFetcher.API.Models;
using BookFetcher.Application.Factory;
using BookFetcher.Domain.Models;
using BookFetcher.Application.DTOs.BookDTO;

namespace BookFetcher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Variables + Constuctor
        private readonly IBookService _bookService;
        private readonly IBookFactory _bookFactory;

        public BookController(IBookService bookService, IBookFactory bookFactory)
        {
            _bookService = bookService;
            _bookFactory = bookFactory;
        }
        #endregion

        #region Get All 

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Pagination model)
        {
            if (model == null)
            {
                return BadRequest("Pagination model is required!");
            }

            model.SetDefaults();
            GetAllBookResponse response = await _bookService.GetAllAsync(model.CurrentPage, model.PageSize);
            return Ok(response);
        }

        #endregion

        #region Get by ID

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetBookByIdRequest request = new GetBookByIdRequest { BookId = id };
            GetBookByIdResponse? response = await _bookService.GetByIdAsync(request);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        #endregion

        #region Add

        [HttpPost]
        public async Task<IActionResult> Add(PostBookRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            PostBookResponse response = await _bookService.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.BookId }, response);
        }

        #endregion

        #region Delete 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteBookRequest request = new DeleteBookRequest { BookId = id };
            DeleteBookResponse response = await _bookService.DeleteAsync(request);
            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }

        #endregion
    }
}
