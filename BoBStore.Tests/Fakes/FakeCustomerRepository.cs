
using System;
using System.Collections.Generic;
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

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {

        }
    }

}
