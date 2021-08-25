

using System;
using System.Collections.Generic;
using BoBStore.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BoBStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class CreateOrderCommands : Notifiable<Notification>, ICommands
    {
        public CreateOrderCommands()
        {
            OrderItens = new List<OrderItemCommands>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemCommands> OrderItens { get; set; }

        public bool Valid()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(Customer.ToString(), 37, "Customer", "O ID do cliente está inválido.")
                .IsGreaterThan(Customer.ToString(), 35, "Customer", "O ID do cliente está inválido.")
                .IsGreaterThan(OrderItens.Count, 0, "Items", "Nenhum item do pedido foi encontrado.")

            );
            return IsValid;
        }
    }

    public class OrderItemCommands
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }


}