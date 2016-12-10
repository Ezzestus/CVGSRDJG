/* Filename: Wish_ListTest.cs
 * Description: This class is responsible for unit testing for the Wish_List class.
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
    public class Wish_ListTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void Wish_ListTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Wish_List wishList = new Wish_List();

            // Assert
            Assert.IsNotNull(wishList);
        }

        [Test]
        // This test is responsible for checking the wish_list_id field
        public void Wish_ListTest_WishListIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Wish_List wishList = new Wish_List();
            int expected = 23;
            int actual;

            // Act
            wishList.wish_list_id = expected;

            // Assert
            actual = wishList.wish_list_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the user_id field
        public void Wish_ListTest_UserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Wish_List wishList = new Wish_List();
            int expected = 23;
            int actual;

            // Act
            wishList.user_id = expected;

            // Assert
            actual = wishList.user_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the game_id field
        public void Wish_ListTest_GameIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Wish_List wishList = new Wish_List();
            int expected = 23;
            int actual;

            // Act
            wishList.game_id = expected;

            // Assert
            actual = wishList.game_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the date_added field
        public void Wish_ListTest_DateAddedWithCorrectType_ShouldPass()
        {
            // Arrange
            Wish_List wishList = new Wish_List();
            DateTime expected = new DateTime(1995, 12, 23);
            DateTime actual = new DateTime();

            // Act
            wishList.date_added = expected;

            // Assert
            actual = wishList.date_added;
            Assert.AreEqual(expected, actual);
        }
    }
}
