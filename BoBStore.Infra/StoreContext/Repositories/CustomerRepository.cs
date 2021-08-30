using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BobStore.Infra.DataContexts;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.Queries;
using BoBStore.Domain.StoreContext.Repositories;
using Dapper;

namespace BobStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BoBDataContext _context;
        public CustomerRepository(BoBDataContext context)
        {
            _context = context;
        }

        // Função responsável por verificar no BD se o documento já existe.
        public bool CheckDocument(string document)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();
        }

        // Função responsavel por verificar se o email já existe no DB
        public bool CheckEmail(string email)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();
        }

        // Lembrete: Criar a stored procedure no db
        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context
               .Connection
               .Query<CustomerOrdersCountResult>(
                   "spGetCustomerOrdersCount",
                   new { Document = document },
                   commandType: CommandType.StoredProcedure)
               .FirstOrDefault();
        }

        // Função responsavel por registrar o Customer no BD
        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
            new
            {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document,
                Email = customer.Email,
                Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);

            //  Responsavel por registrar todos os endereços de um cliente.
            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}