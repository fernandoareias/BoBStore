

using System;
using BoBStore.Shared.Entities;

namespace BoBStore.Domain.StoreContext.Entities
{
    public class Product  : Entity
    {
        public Product(string title, string description, decimal price, string image, int quantity)
        {
            Title = title;
            Description = description;
            Price = price;
            Image = image;
            Quantity = quantity;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return Title;
        }

        public void DecreaseQuantity(int quantity)
        {
            Quantity -= quantity;
        }
    }
}