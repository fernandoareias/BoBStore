

using BoBStore.Domain.StoreContext.Entities;

namespace BoBStore.Domain.StoreContext.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}