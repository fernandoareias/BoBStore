

using System;
using BoBStore.Domain.StoreContext.CustomerCommands.Inputs;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Shared.Commands;
using Flunt.Notifications;

namespace BoBStore.Domain.StoreContext.Handlers
{
    public class CustommerHandler : Notifiable<Notification>,
                                    ICommandHandler<CreateCustomerCommand>,
                                    ICommandHandler<AddAddressCommands>
    {
        public ICommandResult Handler(CreateCustomerCommand Command)
        {

            // Verifica se o CPF ja existe na base

            // Verifica se o E-Mail ja existe na base

            // Cria os VOs
            var name = new Name(Command.FirstName, Command.LastName);
            var document = new Document(Command.Document);
            var email = new Email(Command.Email);
            // Cria entidade
            var customer = new Customer(name, document, email, Command.Phone);

            // Validar entidades e VOs
            AddNotifications(name, document, email, customer);

            // Cria a entidade

            // Persiste o cliente

            // Envia um e-mail de boas vindas

            // Retorna o resultado na tela

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handler(AddAddressCommands Command)
        {
            throw new System.NotImplementedException();
        }
    }
}