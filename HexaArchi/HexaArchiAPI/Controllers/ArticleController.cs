using HexaArchi.Application.DTOs.ArticleDTO;
using HexaArchi.Application.DTOs.AuthorDTO;
using HexaArchi.Application.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace HexaArchi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        #region Variables + Constructor

        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        #endregion

        #region Get By ID

        [HttpGet("{id}")]
        public async Task<ActionResult<GetArticleByIdResponse>> GetById(Guid id)
        {
            GetArticleByIdResponse? response = await _articleService.GetByIdAsync(new GetArticleByIdRequest { ArticleId = id });

            if (response == null)
            {
                return NotFound(new { Message = "Article not found" });
            }

            return Ok(response);
        }

        #endregion

        #region Get All

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetAll()
        {
            IEnumerable<ArticleDto> articles = await _articleService.GetAllAsync();
            return Ok(articles);
        }

        #endregion

        #region Add

        [HttpPost]
        public async Task<ActionResult<PostArticleResponse>> Add(PostArticleRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { Message = "Invalid article data." });
            }

            PostArticleResponse? response = await _articleService.AddAsync(request);

            if (response == null)
            {
                return BadRequest(new { Message = "Failed to add the article" });
            }

            return CreatedAtAction(nameof(GetById), new { id = response.ArticleId }, response);
        }

        #endregion

        #region Update

        [HttpPut("{id}")]
        public async Task<ActionResult<PutArticleResponse>> Update(Guid id, PutArticleRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { Message = "Invalid article data." });
            }

            PutArticleResponse? response = await _articleService.UpdateAsync(id, request);

            if (response == null || !response.Success)
            {
                return BadRequest(new { Message = "Failed to update the article" });
            }

            return Ok(response);
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            DeleteArticleResponse? response = await _articleService.DeleteAsync(new DeleteArticleRequest { ArticleId = id });

            if (!response.Success)
            {
                return NotFound(new { Message = "Article not found or could not be deleted!!!!!!" });
            }

            return NoContent();
        }

        #endregion
    }
}
