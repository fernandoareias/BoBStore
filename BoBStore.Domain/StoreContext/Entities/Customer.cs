

using System;
using System.Collections.Generic;
using System.Linq;
using BoBStore.Domain.StoreContext.ValueObjects;
using Flunt.Notifications;

namespace BoBStore.Domain.StoreContext.Entities
{
    public class Customer : Notifiable<Notification>
    {
        private readonly IList<Address> _addresses;
        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray(); // get { return _addresses.ToArray(); } 

        public void Address(Address item)
        {
            // Validar
            // Adicionar
            _addresses.Add(item);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}