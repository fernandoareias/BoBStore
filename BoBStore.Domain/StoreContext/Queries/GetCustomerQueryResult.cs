

using System;

namespace BoBStore.Domain.StoreContext.Queries

{// Get By Id
    public class GetCustomerQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public int Email { get; set; }

    }
}