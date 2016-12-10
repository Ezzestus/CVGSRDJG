/* Filename: DeveloperTest.cs
 * Description: This class is responsible for unit testing for the Developer class.
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

namespace VideoGameStore.Tests
{
    [TestFixture]
    public class DeveloperTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void DeveloperTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Developer developer = new Developer();

            // Assert
            Assert.IsNotNull(developer);
        }

        [Test]
        // This test is responsible for checking the developer_id field
        public void DeveloperTest_DeveloperIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Developer developer = new Developer();
            int expected = 7;        
            int actual;

            // Act
            developer.developer_id = expected;

            // Assert
            actual = developer.developer_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the developer_name field
        public void DeveloperTest_DeveloperNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Developer developer = new Developer();
            string expected = "Blizzard Entertainment";
            string actual;

            // Act
            developer.developer_name = expected;

            // Assert
            actual = developer.developer_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the contact_name field
        public void DeveloperTest_ContactNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Developer developer = new Developer();
            string expected = "Bill Ese";
            string actual;

            // Act
            developer.contact_name = expected;

            // Assert
            actual = developer.contact_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the contact_phone field
        public void DeveloperTest_ContactPhoneNumberWithCorrectType_ShouldPass()
        {
            // Arrange
            Developer developer = new Developer();
            string expected = "(519) 009 - 7765";
            string actual;

            // Act
            developer.contact_phone = expected;

            // Assert
            actual = developer.contact_phone;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the contact_email field
        public void DeveloperTest_ContactEmailWithCorrectType_ShouldPass()
        {
            // Arrange
            Developer developer = new Developer();
            string expected = "Bill@Ese.com";
            string actual;

            // Act
            developer.contact_email = expected;

            // Assert
            actual = developer.contact_email;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Contact Name validation (value in lowercase characters)
        public void DeveloperTest_Validation_ContactNameLowerCase_ShouldCapitalizeFirstLetterOfEachWord()
        {
            // Arrange
            Developer developer = new Developer();
            string contactName = RPValidations.Capitalize("homer simpson", true);
            string expected = "Homer Simpson";

            // Act
            developer.contact_name = contactName;

            // Assert
            string actual = developer.contact_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Phone Number validation (value including dash delimiters)
        public void DeveloperTest_Validation_PhoneNumberWithDashes_ShouldRemoveDashes()
        {
            // Arrange
            Developer developer = new Developer();
            string phone = RPValidations.FormatPhoneNumber("000-000-0000");            
            string expected = "0000000000";

            // Act
            developer.contact_phone = phone;

            // Assert
            string actual = developer.contact_phone;
            Assert.AreEqual(expected, actual);
        }
    }
}
