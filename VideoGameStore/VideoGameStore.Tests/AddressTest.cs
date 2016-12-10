/* Filename: AddressTest.cs
 * Description: This class is responsible for unit testing for the Address class.
 * 
 * Revision History:
 *      Greg Shalay 2016-10-27: Created constructor and field tests.
 *      Ryan Pease 2016-10-29: Created validation tests. 
 *      Ryan Pease 2016-11-01: Updated formatting and method names. 
*/

using System;
using NUnit.Framework;
using VideoGameStore.Models;
using RPClassLibrary;

namespace VideoGameStore.Tests
{
    [TestFixture]
    public class AddressTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void AddressTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Address address = new Address();

            // Assert
            Assert.IsNotNull(address);
        }

        [Test]
        // This test is responsible for checking the address_id field
        public void AddressTest_AddressIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Address address = new Address();
            int expected = 1212;
            int actual;

            // Act
            address.address_id = expected;

            // Assert
            actual = address.address_id;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        // This test is responsible for checking the address field
        public void AddressTest_StreetAddressWithCorrectType_ShouldPass()
        {
            // Arrange
            Address address = new Address();
            string expected = "123 Fakeville North";
            string actual;

            // Act
            address.street_address = expected;

            // Assert
            actual = address.street_address;        
            Assert.AreEqual(actual, expected);
        }

        [Test]
        // This test is responsible for checking the city field
        public void AddressTest_CityWithCorrectType_ShouldPass()
        {
            // Arrange
            Address address = new Address();
            string expected = "The Most Awesome City!";
            string actual;

            // Act
            address.city = expected;

            // Assert
            actual = address.city;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        // This test is responsible for checking the province_id field
        public void AddressTest_ProvinceIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Address address = new Address();
            int expected = 23;
            int actual;

            // Act
            address.province_id = expected;

            // Assert
            actual = address.province_id;
            Assert.AreEqual(address.province_id, expected);
        }

        [Test]
        // This test is responsible for checking the postal code field
        public void AddressTest_PostalCodeWithCorrectType_ShouldPass()
        {
            // Arrange
            Address address = new Address();
            string expected = "A1A 1A1";
            string actual;

            // Act
            address.postal_code = expected;

            // Assert
            actual = address.postal_code;
            Assert.AreEqual(actual, expected);
        }
        
        [Test]
        // This test is responsible for checking the Postal Code validation (value includes a space)
        public void AddressTest_Validation_PostalCodeWithSpace_ShouldRemoveSpace()        
        {
            // Arrange
            Address address = new Address();
            string postalCode = RPValidations.FormatPostalCode("L0L 0L0");                
            string expected = "L0L0L0";            

            // Act
            address.postal_code = postalCode;

            // Assert
            string actual = address.postal_code;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Postal Code validation (value in lowercase characters)
        public void AddressTest_Validation_PostalCodeWithLowerCase_ShouldMakeUpperCase()
        {
            // Arrange
            Address address = new Address();
            string postalCode = RPValidations.FormatPostalCode("l0l0l0");
            string expected = "L0L0L0";

            // Act
            address.postal_code = postalCode;

            // Assert           
            string actual = address.postal_code;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Street Address validation (value in lowercase characters)
        public void AddressTest_Validation_AddressWithLowerCase_ShouldMakeFirstLetterOfEachWord()
        {
            // Arrange
            Address address = new Address();
            string address1 = RPValidations.Capitalize("202 hello hello st", true);
            string expected = "202 Hello Hello St";

            // Act
            address.street_address = address1;

            // Assert
            string actual = address.street_address;
            Assert.AreEqual(expected, actual);
        }
    }
}
