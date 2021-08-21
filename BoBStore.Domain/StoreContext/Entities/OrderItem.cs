

using System;

namespace BoBStore.Domain.StoreContext.Entities
{
    public class OrderItem
    {
        public OrderItem(Product product, string quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;
        }

        public Product Product { get; private set; }
        public string Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}