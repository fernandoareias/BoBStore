

using System;
using Flunt.Notifications;

namespace BoBStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable<Notification>
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.Quantity < quantity)
                AddNotification("Quantity", "Produto fora de estoque");
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}