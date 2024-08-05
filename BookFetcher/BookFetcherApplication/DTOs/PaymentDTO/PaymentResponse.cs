namespace BookFetcher.Application.DTOs.PaymentDTO
{
    public class PaymentResponse
    {
        public bool Success { get; set; }
        public required string TransactionId { get; set; }
        public required string Message { get; set; }
    }

}
