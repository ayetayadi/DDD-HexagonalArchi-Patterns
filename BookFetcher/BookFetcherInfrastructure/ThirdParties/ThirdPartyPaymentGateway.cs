namespace BookFetcher.Infrastructure.ThirdParties
{
    public class ThirdPartyPaymentGateway
    {
        public async Task ExecutePayment(decimal amount, string currency)
        {
            await Task.Delay(100);
            Console.WriteLine($"Payment processed: {amount} {currency}");
        }
    }

}
