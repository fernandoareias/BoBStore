

using Flunt.Notifications;
using Flunt.Validations;

namespace BoBStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable<Notification>
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Notification>()
             .Requires()
             .IsEmail(Address, "Email", "O E-mail é invalido.")
         );
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }

    }
}