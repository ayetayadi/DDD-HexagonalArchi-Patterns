namespace BookFetcher.Application.Ports.Driving
{
    public interface IPaymentProcessor
    {
        Task ProcessPaymentAsync(decimal amount, string currency);
    }

}
