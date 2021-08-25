using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoBStore.Domain.StoreContext.ValueObjects;
using BoBStore.Domain.StoreContext.Entities;
namespace BoBStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document _validDocument;
        private Document _invalidDocument;

        public DocumentTests()
        {
            _validDocument = new Document("35303735591");
            _invalidDocument = new Document("353037355911");
        }
        [TestMethod]
        public void DeveRetornaNotificationQuandoDocumentoEInvalido()
        {
            Assert.AreEqual(false, _invalidDocument.IsValid);
            // Assert.AreEqual(1, _invalidDocument.Notifications.Count);
        }


        [TestMethod]
        public void NaoDeveRetornaNotificationQuandoDocumentoEValido()
        {

            Assert.AreEqual(true, _validDocument.IsValid);
            // Assert.AreEqual(0, _validDocument.Notifications.Count);
        }
    }
}
