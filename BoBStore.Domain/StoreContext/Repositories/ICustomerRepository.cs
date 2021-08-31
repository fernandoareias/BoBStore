

using System;
using System.Collections.Generic;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.Queries;

namespace BoBStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult GetById(Guid Id);
        IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id);
    }
}