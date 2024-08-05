using HexaArchi.Application.DTOs.WritingDTO;
using HexaArchi.Application.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace HexaArchi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WritingController : ControllerBase
    {
        #region Variables + Constructor

        private readonly IWritingService _writingService;

        public WritingController(IWritingService writingService)
        {
            _writingService = writingService;
        }

        #endregion

        #region Change Article Status

        [HttpPost("change-status")]
        public async Task<ActionResult<ChangeArticleStatusResponse>> ChangeArticleStatus(ChangeArticleStatusRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { Message = "Invalid ChangeArticleStatus data." });
            }

            ChangeArticleStatusResponse? response = await _writingService.ChangeArticleStatusAsync(request);

            if (!response.Success)
            {
                return BadRequest(new { Message = response.Message });
            }

            return Ok(response);
        }

        #endregion

        #region Start Writing
        [HttpPost("start-writing")]
        public async Task<ActionResult<StartWritingResponse>> StartWriting(StartWritingRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { Message = "Invalid start writinh data" });
            }

            StartWritingResponse? response = await _writingService.StartWritingAsync(request);

            if (!response.Success)
            {
                return BadRequest(new { Message = response.Message });
            }

            return Ok(response);
        }

        #endregion
    }
}
