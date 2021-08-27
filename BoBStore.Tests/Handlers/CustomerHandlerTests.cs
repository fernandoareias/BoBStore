

using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.CustomerCommands.Inputs;
using BoBStore.Domain.StoreContext.Handlers;

namespace BoBStore.Tests.ValueObjects
{
    [TestClass]
    public class CustomerHandlerTest
    {

        [TestMethod]
        public void DeveRegistrarClienteQuandoCommandEValido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Bob";
            command.LastName = "Bobson";
            command.Document = "35303735591";
            command.Email = "bob@bob.com.br";
            command.Phone = "5521992446487";

            Assert.AreEqual(true, command.Valid());

            // Testa sem depender de BDs
            var handler = new CustommerHandler(new FakeCustomerRepository(), new FakeEmailService());
        }
    }

}
