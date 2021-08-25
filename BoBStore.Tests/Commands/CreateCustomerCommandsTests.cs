

using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.CustomerCommands.Inputs;

namespace BoBStore.Tests.ValueObjects
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void DeveValidarQuandoCommandForValido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Bob";
            command.LastName = "Bobson";
            command.Document = "35303735591";
            command.Email = "bob@bob.com.br";
            command.Phone = "5521992446487";

            Assert.AreEqual(true, command.Valid());

        }
    }

}
