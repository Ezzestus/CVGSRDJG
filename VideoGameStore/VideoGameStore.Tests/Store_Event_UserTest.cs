/* Filename: Store_Event_UserTest.cs
 * Description: This class is responsible for unit testing for the Store_Event_User class.
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
    public class Store_Event_UserTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void Store_Event_UserTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Store_Event_User sec = new Store_Event_User();

            // Assert
            Assert.IsNotNull(sec);
        }

        [Test]
        // This test is responsible for checking the store_event_user_id field
        public void Store_Event_UserTest_StoreEventUserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_User sec = new Store_Event_User();
            int expected = 999;
            int actual;

            // Act
            sec.store_event_user_id = expected;
            actual = sec.store_event_user_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the store_event_id field
        public void Store_Event_UserTest_StoreEventIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_User sec = new Store_Event_User();
            int expected = 12;
            int actual;

            // Act
            sec.store_event_id = expected;
            actual = sec.store_event_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the user_id field
        public void Store_Event_UserTest_UserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_User sec = new Store_Event_User();
            int expected = 999;
            int actual;

            // Act
            sec.user_id = expected;
            actual = sec.user_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
