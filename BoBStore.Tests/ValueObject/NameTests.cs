using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Domain.StoreContext.Entities;
namespace BoBStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {

        [TestMethod]
        public void DeveRetornaNotificationQuandoNomeEInvalido()
        {
            var _invalidName = new Name("", "Areias");
            Assert.AreEqual(false, _invalidName.IsValid);
            Assert.AreEqual(1, _invalidName.Notifications.Count);
        }

        [TestMethod]
        public void NaoDeveRetornaNotificationQuandoNomeEValido()
        {
            var _validName = new Name("Fernando", "Areias");
            Assert.AreEqual(true, _validName.IsValid);
            Assert.AreEqual(0, _validName.Notifications.Count);
        }
    }



}
