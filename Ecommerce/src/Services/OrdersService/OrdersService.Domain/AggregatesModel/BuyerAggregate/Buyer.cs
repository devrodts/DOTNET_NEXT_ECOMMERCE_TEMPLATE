using System.ComponentModel.DataAnnotations;
using Ecommerce.src.Services.OrdersService.OrdersService.Domain.AggregatesModel.BuyerAggregate;
using Ecommerce.src.Services.OrdersService.OrdersService.Domain.Events;
using Ecommerce.src.Services.OrdersService.OrdersService.Domain.SeedWork;
using Ecommerce.src.Services.UsersService.UsersService.Domain.SeedWork;

namespace Ecommerce.src.Services.UsersService.UsersService.Domain.AggregatesModel.BuyerAggregate
{

    public class Buyer
                : Entity, IAggregateRoot
    {
        [Required]
        public string IdentityGuid { get; private set; }

        [Required]
        public string Name { get; private set; }

        private List<PaymentMethod> _paymentMethods;

        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

        protected Buyer()
        {
            IdentityGuid = string.Empty;
            Name = string.Empty;
            _paymentMethods = new List<PaymentMethod>();
        }

        public Buyer(string identity, string name) : this()
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        }


        public PaymentMethod VerifyOrAddPaymentMethod(
            int cardTypeId, 
            string alias, 
            string cardNumber,
            string securityNumber, 
            string cardHolderName, 
            DateTime expiration, 
            Guid orderId
         )
        {
            var existingPayment = _paymentMethods
                .SingleOrDefault(p => p.IsEqualTo(cardTypeId, cardNumber, expiration));

            if (existingPayment is not null)
            {
                AddDomainEvent(new BuyerAndPaymentMethodVerifiedDomainEvent(this, existingPayment, orderId));

                return existingPayment;
            }

            var payment = new PaymentMethod(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration);

            _paymentMethods.Add(payment);

            AddDomainEvent(new BuyerAndPaymentMethodVerifiedDomainEvent(this, payment, orderId));

            return payment;
        }
    }

}
