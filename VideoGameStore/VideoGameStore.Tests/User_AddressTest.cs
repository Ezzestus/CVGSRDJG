/* Filename: User_AddressTest.cs
 * Description: This class is responsible for unit testing for the User_Address class.
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
    public class User_AddressTest
    {       
        [Test]
        // This test is responsible for checking the constructor
        public void User_AddressTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            User_Address userAddress = new User_Address();

            // Assert
            Assert.IsNotNull(userAddress);
        }

        [Test]
        // This test is responsible for checking the user_id field
        public void User_AddressTest_UserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            User_Address userAddress = new User_Address();
            int expected = 10;
            int actual;

            // Act
            userAddress.user_id = expected;

            // Assert
            actual = userAddress.user_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the address_id field
        public void User_AddressTest_AddressIDWithCorrectType_ShouldPass()
        {
            // Arrange
            User_Address userAddress = new User_Address();
            int expected = 10;
            int actual;

            // Act
            userAddress.address_id = expected;

            // Assert
            actual = userAddress.address_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the address_name field
        public void User_AddressTest_AddressNameWithCorrectType_ShouldPass()
        {
            // Arrange
            User_Address userAddress = new User_Address();
            string expected = "23 Wilson Ave";
            string actual;

            // Act
            userAddress.address_name = expected;

            // Assert
            actual = userAddress.address_name;
            Assert.AreEqual(expected, actual);
        }
    }
}
