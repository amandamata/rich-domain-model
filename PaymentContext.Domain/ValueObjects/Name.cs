using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
             AddNotifications(new Contract<Name>()
                .Requires()
                .IsNullOrEmpty(FirstName, "Name.FirstName", "Invalid first name")
                .IsNullOrEmpty(LastName, "Name.LastName", "Invalid last name")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";            
        }
    }
}
