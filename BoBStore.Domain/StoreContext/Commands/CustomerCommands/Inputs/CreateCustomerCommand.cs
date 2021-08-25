

using Flunt.Notifications;
using Flunt.Validations;

namespace BoBStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable<Notification>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //  Fail Fast Validations 
        public bool Valid()
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsLowerThan(FirstName, 42, "FirstName", "O nome não pode ser maior que 42 caractéres.")
               .IsGreaterThan(FirstName, 3, "FirstName", "O nome deve ser maior que 3 caractéres")
               .IsLowerThan(LastName, 42, "LastName", "O sobrenome deve ser menor que 42 caractéres.")
               .IsGreaterThan(LastName, 3, "LastName", "O sobrenome deve ser maior que 3 caractéres.")
               .IsEmail(Email, "Email", "O E-mail é invalido.")
               .IsLowerThan(Document, 11, "Document", "CPF Inválido.")
           );
            return Valid();
        }
    }
}