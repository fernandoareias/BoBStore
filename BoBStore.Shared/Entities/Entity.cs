

using System;
using Flunt.Notifications;

namespace BoBStore.Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
    }
}