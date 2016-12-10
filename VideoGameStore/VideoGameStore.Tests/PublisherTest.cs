/* Filename: PublisherTest.cs
 * Description: This class is responsible for unit testing for the Publisher class.
 * 
 * Revision History:
 *      Greg Shalay 2016-10-27: Created constructor and field tests. 
 *      Ryan Pease 2016-10-30: Created validation tests.
 *      Ryan Pease 2016-11-01: Updated formatting and method names. 
*/

using System;
using NUnit.Framework;
using VideoGameStore.Models;
using RPClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace VideoGameStore.Tests
{
    [TestFixture]
    public class PublisherTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void PublisherTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Publisher publisher = new Publisher();

            // Assert
            Assert.IsNotNull(publisher);
        }

        [Test]
        // This test is responsible for checking the publisher_name field
        public void PublisherTest_PublisherNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Publisher publisher = new Publisher();
            string expected = "The Real Publisher";
            string actual;

            // Act
            publisher.publisher_name = expected;

            // Assert
            actual = publisher.publisher_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the contact_name field
        public void PublisherTest_ContactNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Publisher publisher = new Publisher();
            string expected = "Jill Dennings";
            string actual;

            // Act
            publisher.contact_name = expected;

            // Assert
            actual = publisher.contact_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the contact_phone field
        public void PublisherTest_ContactPhoneWithCorrectType_ShouldPass()
        {
            // Arrange
            Publisher publisher = new Publisher();
            string expected = "(555) 555-5555";
            string actual;

            // Act
            publisher.contact_phone = expected;
            actual = publisher.contact_phone;

            // Assert
            Assert.AreEqual(expected, actual);
        }    

        [Test]
        // This test is responsible for checking the contact_email field
        public void PublisherTest_ContactEmailWithCorrectType_ShouldPass()
        {
            // Arrange
            Publisher publisher = new Publisher();
            string expected = "publisher@publish.ca";
            string actual;

            // Act
            publisher.contact_email = expected;

            // Assert
            actual = publisher.contact_email;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Contact Name validation (value in lowercase characters)
        public void PublisherTest_Validation_ContactNameLowerCase_ShouldCapitalizeFirstLetterOfEachWord()
        {
            // Arrange
            Publisher publisher = new Publisher();
            string contactName = RPValidations.Capitalize("frank sinatra", true);
            string expected = "Frank Sinatra";

            // Act
            publisher.contact_name = contactName;

            // Assert
            string actual = publisher.contact_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Phone Number validation (value including dash delimiters)
        public void PublisherTest_Validation_PhoneNumberWithDashes_ShouldRemoveDashes()
        {
            // Arrange
            Publisher publisher = new Publisher();
            string phone = RPValidations.FormatPhoneNumber("000-000-0000");
            string expected = "0000000000";

            // Act
            publisher.contact_phone = phone;

            // Assert
            string actual = publisher.contact_phone;
            Assert.AreEqual(expected, actual);
        }
    }
}
