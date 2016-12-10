/* Filename: InvoiceTest.cs
 * Description: This class is responsible for unit testing for the Invoice class.
 * 
 * Revision History:
 *      Greg Shalay 2016-10-27: Created constructor and field tests. 
 *      Ryan Pease 2016-11-01: Updated formatting and method names. 
*/

using System;
using NUnit.Framework;
using VideoGameStore.Models;

namespace VideoGameStore.Tests
{
    [TestFixture]
    public class InvoiceTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void InvoiceTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Invoice invoice = new Invoice();

            // Assert
            Assert.IsNotNull(invoice);
        }

        [Test]
        // This test is responsible for checking the invoice_id field
        public void InvoiceTest_InvoiceIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice invoice = new Invoice();
            int expected = 45;
            int actual;

            // Act
            invoice.invoice_id = expected;

            // Assert
            actual = invoice.invoice_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the user_id field
        public void InvoiceTest_UserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice invoice = new Invoice();
            int expected = 81;
            int actual;

            // Act
            invoice.user_id = expected;

            // Assert
            actual = invoice.user_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the credit_card_id field
        public void InvoiceTest_CreditCardIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice invoice = new Invoice();
            int expected = 711;
            int actual;

            // Act
            invoice.credit_card_id = expected;

            // Assert
            actual = invoice.credit_card_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the invoice_date field
        public void InvoiceTest_InvoiceDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice invoice = new Invoice();
            DateTime expected = new DateTime(2007, 1, 1);
            DateTime actual = new DateTime();

            // Act
            invoice.invoice_date = expected;

            // Assert
            actual = invoice.invoice_date;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the ship_date field
        public void InvoiceTest_ShipDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice invoice = new Invoice();
            DateTime expected = new DateTime(2009, 12, 3);
            DateTime? actual = new DateTime();

            // Act
            invoice.ship_date = expected;

            // Assert
            actual = invoice.ship_date;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_invoice_closed field
        public void InvoiceTest_IsInvoiceClosedWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice invoice = new Invoice();
            bool expected = true;
            bool actual;

            // Act
            invoice.is_invoice_closed = expected;

            // Assert
            actual = invoice.is_invoice_closed;
            Assert.AreEqual(expected, actual);
        }
    }
}
