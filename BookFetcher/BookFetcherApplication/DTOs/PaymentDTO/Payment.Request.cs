namespace BookFetcher.Application.DTOs.PaymentDTO
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public required string Currency { get; set; }
        public required string PaymentMethodType { get; set; }
        public required string CardNumber { get; set; }
        public required string ExpirationDate { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerEmail { get; set; }
        public required string CustomerPhoneNumber { get; set; }
        public required string CustomerAddress { get; set; }
        public required string TransactionId { get; set; }
    }
}
