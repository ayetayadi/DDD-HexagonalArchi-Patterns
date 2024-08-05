using BookFetcher.Application.DTOs.PaymentDTO;
using BookFetcher.Application.Ports.Driving;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookFetcher.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        #region Variable + Constructor
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentController(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        #endregion

        #region Payment Processing
        [HttpPost]
        public async Task<IActionResult> Post(PaymentRequest request)
        {
            if (request == null)
            {
                return BadRequest("Null request");
            }
            try
            {
                await _paymentProcessor.ProcessPaymentAsync(request.Amount, request.PaymentMethodType);

                PaymentResponse response = new PaymentResponse
                {
                    Success = true,
                    TransactionId = request.TransactionId,
                    Message = "Payment processed successfully"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                PaymentResponse response = new PaymentResponse
                {
                    Success = false,
                    TransactionId = request.TransactionId,
                    Message = $"Payment processing failed: {ex.Message}"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        #endregion
    }
}
