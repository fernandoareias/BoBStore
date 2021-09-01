
using System;
using System.Collections.Generic;
using BoBStore.Domain.StoreContext.CustomerCommands.Inputs;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.Handlers;
using BoBStore.Domain.StoreContext.Queries;
using BoBStore.Domain.StoreContext.Repositories;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BoBStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustommerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustommerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        [HttpGet]
        [Route("v1/clientes")]
        [ResponseCache(Duration = 60)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/clientes/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.GetById(id);
        }
        [HttpGet]
        [Route("v1/clientes/{id}/pedidos")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }


        [HttpPost]
        [Route("v1/clientes")]
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            // Raliza o parse para CreateCustomerCommandResult
            var result = (CreateCustomerCommandResult)_handler.Handler(command);
            if (_handler.IsValid == false)
                return result;
            return result;

        }




    }
}