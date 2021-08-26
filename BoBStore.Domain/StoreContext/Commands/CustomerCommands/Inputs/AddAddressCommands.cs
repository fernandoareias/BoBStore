

using System;
using BoBStore.Domain.StoreContext.Enums;
using BoBStore.Shared.Commands;
using Flunt.Notifications;

namespace BoBStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class AddAddressCommands : Notifiable<Notification>, ICommands
    {
        public Guid Id { get; set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType Type { get; private set; }

        public bool Valid()
        {
            return IsValid;
        }
    }
}