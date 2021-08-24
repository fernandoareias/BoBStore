using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoBStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Fernando", "Areias");
            var document = new Document("14270066792");
            var email = new Email("nando.calheirosx@gmail.com");
            var client = new Customer(name, document, email, "21992546466");
            var mouse = new Product("Mouse", "Rato", 59.90M, "img.png", 10);
            var order = new Order(client);
            order.AddItem(new OrderItem(mouse, 5));

            // Gera o pedido
            order.Place();

            // Simula o pagamento
            order.Pay();

            // Simular o envio
            order.Ship();

            // Simular o cancelamento
            order.Cancel();

        }
    }
}
