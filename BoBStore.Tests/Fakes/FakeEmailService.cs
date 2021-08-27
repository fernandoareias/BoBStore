
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.Repositories;
using BoBStore.Domain.StoreContext.Services;

namespace BoBStore.Tests.ValueObjects
{

    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {

        }
    }

}
