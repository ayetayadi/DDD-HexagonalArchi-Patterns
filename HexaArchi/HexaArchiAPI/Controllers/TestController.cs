using HexaArchi.Application.Ports.Driven;
using HexaArchi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HexaArchi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        #region Variables + Constructor

        private readonly IMessagePublisher _messagePublisher;

        public TestController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        #endregion

        #region Publish Message

        [HttpPost("publish")]
        public async Task<IActionResult> PublishMessage(Message message)
        {
            if (message == null)
            {
                return BadRequest("Message can't be null");
            }

            await _messagePublisher.PublishMessageAsync(message);
            return Ok("Message published successfully");
        }

        #endregion
    }
}
