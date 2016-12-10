/* Filename: Friend_ListTest.cs
 * Description: This class is responsible for unit testing for the Friend_List class.
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
    public class Friend_ListTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void Friend_ListTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Friend_List friendList = new Friend_List();

            // Assert
            Assert.IsNotNull(friendList);
        }

        [Test]
        // This test is responsible for checking the user_id field
        public void Friend_ListTest_UserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Friend_List friendList = new Friend_List();
            int expected = 34;
            int actual;

            // Act
            friendList.user_id = expected;

            // Assert
            actual = friendList.user_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the friend_id field
        public void Friend_ListTest_FriendIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Friend_List friendList = new Friend_List();
            int expected = 34;
            int actual;

            // Act
            friendList.friend_id = expected;

            // Assert
            actual = friendList.friend_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_family field
        public void Friend_ListTest_IsFamilyWithCorrectType_ShouldPass()
        {
            // Arrange
            Friend_List friendList = new Friend_List();
            bool expected = true;
            bool actual;

            // Act
            friendList.is_family = expected;

            // Assert
            actual = friendList.is_family;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the date_added field
        public void Friend_ListTest_DateAddedWithCorrectType_ShouldPass()
        {
            // Arrange
            Friend_List friendList = new Friend_List();
            DateTime expected = new DateTime();
            DateTime actual = new DateTime();

            // Act
            friendList.date_added = expected;

            // Assert
            actual = friendList.date_added;
            Assert.AreEqual(expected, actual);
        }
    }
}
