

using System;
using BoBStore.Domain.StoreContext.CustomerCommands.Inputs;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.Repositories;
using BoBStore.Domain.StoreContext.Services;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Shared.Commands;
using BoBStores.Domain.StoreContext.CustomerCommands.Inputs;
using Flunt.Notifications;

namespace BoBStore.Domain.StoreContext.Handlers
{
    public class CustommerHandler : Notifiable<Notification>,
                                    ICommandHandler<CreateCustomerCommand>,
                                    ICommandHandler<AddAddressCommands>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustommerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handler(CreateCustomerCommand Command)
        {
            // Verifica se o CPF ja existe na base
            if (_repository.CheckDocument(Command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            // Verifica se o E-Mail ja existe na base
            if (_repository.CheckEmail(Command.Email))
                AddNotification("Email", "Este E-mail já está registrado.");

            // Cria os VOs
            var name = new Name(Command.FirstName, Command.LastName);
            var document = new Document(Command.Document);
            var email = new Email(Command.Email);

            // Cria entidade
            var customer = new Customer(name, document, email, Command.Phone);

            // Validar entidades e VOs
            AddNotifications(name, document, email, customer);

            // Persiste o cliente
            _repository.Save(customer);

            // Envia um e-mail de boas vindas
            _emailService.Send(email.Address, "hello@bob.com", "Hello", "Welcome to BoB Store :)");
            // Retorna o resultado na tela

            // Retornar o resultado para tela
            return new CommandResult(true, "Welcome to BoB Store :)", new
            {
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handler(AddAddressCommands Command)
        {
            throw new System.NotImplementedException();
        }
    }
}