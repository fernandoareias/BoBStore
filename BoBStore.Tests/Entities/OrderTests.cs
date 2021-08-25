using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Domain.StoreContext.Entities;
using BoBStore.Domain.StoreContext.Enums;

namespace BoBStore.Tests.ValueObjects
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _teclado;
        private Product _monitor;

        public OrderTests()
        {
            var name = new Name("Bob", "Bob");
            var document = new Document("32985876648");
            var email = new Email("bob.bob@gmail.com");
            _customer = new Customer(name, document, email, "21992568576");
            _order = new Order(_customer);

            _mouse = new Product("Mouse", "Mouse mouse", 15.0M, "mouse.png", 10);
            _teclado = new Product("Teclado", "Teclado teclado", 10.0M, "teclado.png", 10);
            _monitor = new Product("Monitor", "Monitor monitor", 30.0M, "monitor.png", 10);


        }



        // Criar um novo pedido
        [TestMethod]
        public void DeveCriarUmPedidoValido()
        {

            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar um pedido o status deve ser created
        [TestMethod]
        public void AoCriarUmPedidoOStatusDeveSerCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void AoCriarNovoItemAQuantidadeDeveMudar()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_teclado, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }
        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void AoAdicionarUmNovoItemDeveSubtrairAQuantidadeDoProduto()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.Quantity, 5);

        }

        // Ao confirmar o pedido, deve gerar um numero
        [TestMethod]
        public void AoConfirmarOPedidoDeveGerarUmNumero()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void AoPagarUmPedidoOStatusDeveSerPago()
        {

            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dado mais 10 produtos, devem haver duas entregas
        [TestMethod]
        public void DadoMais10ProdutosDeveHaverDuasEntregas()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_teclado, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_teclado, 1);
            _order.AddItem(_teclado, 1);

            _order.AddItem(_mouse, 1);
            _order.AddItem(_teclado, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_teclado, 1);
            _order.AddItem(_teclado, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }


        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void AoCancelarOPedidoOStatusDeveSerCancelado()
        {

            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }


        // Ao cancelar o pedido, deve cancelar a entrega
        [TestMethod]
        public void AoCancelarOPedidoDeveCancelarAEntrega()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }

    }
}
