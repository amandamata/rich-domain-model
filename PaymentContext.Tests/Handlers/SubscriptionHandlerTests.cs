using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new MockStudentRepository()
            , new MockEmailService());

            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Lorenzo Cauê Sérgio";
            command.LastName = "Gonçalves";
            command.Document = "11111111111";
            command.Email = "hello@hello";

            command.BarCode = "123456";
            command.BoletoNumber = "1234567";

            command.PaymentNumber = "1234";
            command.PaidDate = System.DateTime.Now;
            command.ExpireDate = System.DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Corp";
            command.PayerDocument = "12345678900";
            command.PayerDocumentType = Domain.Enums.EDocumentType.CNPJ;
            command.PayerEmail = "lorenzocauesergiogoncalves@puenteimoveis.com.br";

            command.Street = "Travessa do Poço";
            command.Number = "183";
            command.Neighborhood = "Vila Embratel";
            command.City = "São Luis";
            command.State = "MA";
            command.Country = "BR";
            command.ZipCode = "65081244";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);

        }
    }
}