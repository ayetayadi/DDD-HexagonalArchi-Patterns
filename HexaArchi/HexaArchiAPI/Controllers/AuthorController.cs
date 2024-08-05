using HexaArchi.Application.DTOs.AuthorDTO;
using HexaArchi.Application.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace HexaArchi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        #region Variables + Constructor

        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        #endregion

        #region Get By ID

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAuthorByIdResponse>> GetById(Guid id)
        {
            GetAuthorByIdResponse? response = await _authorService.GetByIdAsync(new GetAuthorByIdRequest { AuthorId = id });

            if (response == null)
            {
                return NotFound(new { Message = "Author not found" });
            }

            return Ok(response);
        }

        #endregion

        #region Get All

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
        {
            IEnumerable<AuthorDto> authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }

        #endregion

        #region Add

        [HttpPost]
        public async Task<ActionResult<PostAuthorResponse>> Add(PostAuthorRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { Message = "Invalid author data." });
            }

            PostAuthorResponse? response = await _authorService.AddAsync(request);

            if (response == null)
            {
                return BadRequest(new { Message = "Failed to add the author." });
            }

            return CreatedAtAction(nameof(GetById), new { id = response.AuthorId }, response);
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<ActionResult<PutAuthorResponse>> Update(Guid id, PutAuthorRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { Message = "Invalid author data" });
            }

            PutAuthorResponse? response = await _authorService.UpdateAsync(id, request);

            if (response == null || !response.Success)
            {
                return BadRequest(new { Message = "Failed to update the author" });
            }

            return Ok(response);
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            DeleteAuthorResponse? response = await _authorService.DeleteAsync(new DeleteAuthorRequest { AuthorId = id });

            if (!response.Success)
            {
                return NotFound(new { Message = "Author not found or could not be deleted." });
            }

            return Ok(response);
        }

        #endregion
    }
}
