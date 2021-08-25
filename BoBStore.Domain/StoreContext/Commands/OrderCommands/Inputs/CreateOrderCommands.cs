

using System;
using System.Collections.Generic;

namespace BoBStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class CreateOrderCommands
    {
        public Guid Customer { get; set; }
        public IList<OrderItemCommands> OrderItens { get; set; }
    }

    public class OrderItemCommands
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}