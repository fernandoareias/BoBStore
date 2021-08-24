using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Domain.StoreContext.Entities;
namespace BoBStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Bob", "Bob");
<<<<<<< HEAD
            var document = new Document("10089556812");
            var email = new Email("Bob.bob@gmail.com");
            var client = new Customer(name, document, email, "21992564895");
=======
            var document = new Document("19265886599");
            var email = new Email("bob.bob@gmail.com");
            var client = new Customer(name, document, email, "21992546468");
>>>>>>> 8eacf0267720c5c1508cacbada2b96e1bfc74df9
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
