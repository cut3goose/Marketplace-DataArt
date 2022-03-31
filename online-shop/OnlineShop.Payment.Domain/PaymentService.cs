namespace OnlineShop.Payment.Domain
{
    public class PaymentService : IPaymentService
    {
        private decimal DefaultDeliveryPrice = 400;
        
        public decimal GetDeliveryPrice()
        {
            return DefaultDeliveryPrice;
        }
    }
}