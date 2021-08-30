
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.Queries;
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

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {

        }
    }

}
