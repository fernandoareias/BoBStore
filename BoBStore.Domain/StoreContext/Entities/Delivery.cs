

using System;
using BoBStore.Domain.StoreContext.Enums;
using Flunt.Notifications;

namespace BoBStore.Domain.StoreContext.Entities
{
    public class Delivery : Notifiable<Notification>
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDateUpdate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Awaiting;
        }


        public DateTime CreateDateUpdate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            // Se data de entrega for passada, nao entregar.
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}