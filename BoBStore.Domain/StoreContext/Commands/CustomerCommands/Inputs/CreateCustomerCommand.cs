

using Flunt.Notifications;
using Flunt.Validations;
using BoBStore.Shared.Commands;
namespace BoBStore.Domain.StoreContext.CustomerCommands.Inputs
{
    // Modelo para receber via API
    public class CreateCustomerCommand : Notifiable<Notification>, ICommands
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
               .IsLowerThan(FirstName, 40, "FirstName", "O nome não pode ser maior que 42 caractéres.")
               .IsGreaterThan(FirstName, 1, "FirstName", "O nome deve ser maior que 3 caractéres")
               .IsLowerThan(LastName, 40, "LastName", "O sobrenome deve ser menor que 42 caractéres.")
               .IsGreaterThan(LastName, 1, "LastName", "O sobrenome deve ser maior que 3 caractéres.")
               .IsEmail(Email, "Email", "O E-mail é invalido.")
               .IsLowerThan(Document, 12, "Document", "CPF Inválido.")
           );
            return IsValid;
        }
    }
}