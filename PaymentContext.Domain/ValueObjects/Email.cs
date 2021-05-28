using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string email)
        {
            Address = email;
        }

        public string Address { get; set; }
    }
}