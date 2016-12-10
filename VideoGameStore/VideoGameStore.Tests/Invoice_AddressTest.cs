/* Filename: Invoice_AddressTest.cs
 * Description: This class is responsible for unit testing for the Invoice_Address class.
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
    public class Invoice_AddressTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void Invoice_AddressTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Invoice_Address invoiceAddress = new Invoice_Address();

            // Assert
            Assert.IsNotNull(invoiceAddress);
        }

        [Test]
        // This test is responsible for checking the invoice_address_id field
        public void Invoice_AddressTest_InvoiceAddressIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice_Address invoiceAddress = new Invoice_Address();
            int expected = 231;
            int actual;

            // Act
            invoiceAddress.invoice_address_id = expected;
            actual = invoiceAddress.invoice_address_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the invoice_id field
        public void Invoice_AddressTest_InvoiceIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice_Address invoiceAddress = new Invoice_Address();
            int expected = 231;
            int actual;

            // Act
            invoiceAddress.invoice_id = expected;
            actual = invoiceAddress.invoice_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the address_id field
        public void Invoice_AddressTest_AddressIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice_Address invoiceAddress = new Invoice_Address();
            int expected = 231;
            int actual;

            // Act
            invoiceAddress.address_id = expected;
            actual = invoiceAddress.address_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_billing_address field
        public void Invoice_AddressTest_IsBillingAddressWithCorrectType_ShouldPass()
        {
            // Arrange
            Invoice_Address invoiceAddress = new Invoice_Address();
            bool expected = false;
            bool actual;

            // Act
            invoiceAddress.is_billing_address = expected;
            actual = invoiceAddress.is_billing_address;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
