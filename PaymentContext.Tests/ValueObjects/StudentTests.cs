using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void ShuldReturnErrorWhenHadActiveSubscription()
        {
            var name = new Name("Eloá", "Marlene");
            var address = new Address("Rua Medellin", 692, "Itoupavazinha", "Blumenau", "SC", "BR", "89066-715");
            var document = new Document("997.905.100-04", EDocumentType.CPF);
            var email = new Email("eloamarlenedamata_@baptistas.com.br");
            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, name.FirstName, document, address, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            student.AddSubscription(subscription);

            Assert.Fail();
        }

        [TestMethod]
        public void ShuldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var name = new Name("Eloá", "Marlene");
            var document = new Document("997.905.100-04", EDocumentType.CPF);
            var email = new Email("eloamarlene@gmail.com");
            var student = new Student(name, document, email);
            
            
            Assert.Fail();
        }
        [TestMethod]
        public void ShuldReturnSuccessWhenHadNoActiveSubscription()
        {
            Assert.Fail();
        }
    }
}
 