using OnlineShop.Contracts.Payment;

namespace OnlineShop.Payment.Domain.Client
{
    public class PaymentClient : IPaymentClient
    {
        private readonly IPaymentService _paymentService;

        public PaymentClient(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        
        public decimal GetDeliveryPrice()
        {
            return _paymentService.GetDeliveryPrice();
        }
    }
}