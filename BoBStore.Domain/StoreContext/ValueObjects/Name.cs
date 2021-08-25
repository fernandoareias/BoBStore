

using Flunt.Notifications;
using Flunt.Validations;

namespace BoBStore.Domain.StoreContext.ValueObjects
{

    public class Name : Notifiable<Notification>
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(FirstName, 42, "FirstName", "O nome não pode ser maior que 42 caractéres.")
                .IsGreaterThan(firstName, 3, "FirstName", "O nome deve ser maior que 3 caractéres")
                .IsLowerThan(lastName, 42, "LastName", "O sobrenome deve ser menor que 42 caractéres.")
                .IsGreaterThan(lastName, 3, "LastName", "O sobrenome deve ser maior que 3 caractéres.")
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