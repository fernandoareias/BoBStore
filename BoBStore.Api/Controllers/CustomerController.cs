
using System;
using System.Collections.Generic;
using BoBStore.Domain.StoreContext.CustomerCommands.Inputs;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BoBStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("clientes")]
        public List<Customer> Get()
        {
            var name = new Name("Gnar", "Bobson");
            var document = new Document("16007229033");
            var email = new Email("gnar.bobson@gmail.com");
            var client = new Customer(name, document, email, "21992546468");
            var customer = new List<Customer>();
            customer.Add(client);
            System.Console.WriteLine(client.Id);
            return customer;
        }

        [HttpGet]
        [Route("clientes/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Gnar", "Bobson");
            var document = new Document("16007229033");
            var email = new Email("gnar.bobson@gmail.com");
            var client = new Customer(name, document, email, "21992546468");

            return client;
        }
        [HttpGet]
        [Route("clientes/{id}/pedidos")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Gnar", "Bobson");
            var document = new Document("16007229033");
            var email = new Email("gnar.bobson@gmail.com");
            var customer = new Customer(name, document, email, "21992546468");
            var order = new Order(customer);
            var mouse = new Product("Mouse", "Mouse mouse", 15.0M, "mouse.png", 10);
            var teclado = new Product("Teclado", "Teclado teclado", 10.0M, "teclado.png", 10);
            order.AddItem(mouse, 5);
            order.AddItem(teclado, 5);

            var orders = new List<Order>();
            orders.Add(order);
            return orders;
        }


        [HttpPost]
        [Route("clientes")]
        public Customer Post([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var client = new Customer(name, document, email, command.Phone);

            return client;
        }

        [HttpPut]
        [Route("clientes")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var client = new Customer(name, document, email, command.Phone);

            return client;
        }

        [HttpDelete]
        [Route("clientes/{id}")]
        public object Delete(Guid id)
        {
            return new { message = "Cliente removido com sucesso. " };
        }
    }
}