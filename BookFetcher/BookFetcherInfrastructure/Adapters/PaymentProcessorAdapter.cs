using BookFetcher.Application.Ports.Driving;
using BookFetcher.Infrastructure.ThirdParties;

namespace BookFetcher.Infrastructure.Adapters
{
    public class PaymentProcessorAdapter : IPaymentProcessor
    {
        private readonly ThirdPartyPaymentGateway _thirdPartyPaymentGateway;

        public PaymentProcessorAdapter(ThirdPartyPaymentGateway thirdPartyPaymentGateway)
        {
            _thirdPartyPaymentGateway = thirdPartyPaymentGateway;
        }

        public async Task ProcessPaymentAsync(decimal amount, string currency)
        {
            await _thirdPartyPaymentGateway.ExecutePayment(amount, currency);
        }
    }
}
