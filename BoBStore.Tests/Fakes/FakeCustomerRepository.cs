
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.Repositories;

namespace BoBStore.Tests.ValueObjects
{

    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {

        }
    }

}
