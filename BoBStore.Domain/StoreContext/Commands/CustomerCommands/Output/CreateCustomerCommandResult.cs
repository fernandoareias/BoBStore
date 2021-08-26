

using Flunt.Notifications;
using Flunt.Validations;
using BoBStore.Shared.Commands;
using System;

namespace BoBStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult() { }

        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }



    }
}