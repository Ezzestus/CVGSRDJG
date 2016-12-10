/* Filename: User_GameTest.cs
 * Description: This class is responsible for unit testing for the User_Game class.
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
    public class User_GameTest
    {
        [Test]
        // This test is responsible for checking the user_id field
        public void User_GameTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            User_Game userGame = new User_Game();

            // Assert
            Assert.IsNotNull(userGame);
        }

        [Test]
        // This test is responsible for checking the user_game_id field
        public void User_GameTest_UserGameIDWithCorrectType_ShouldPass()
        {
            // Arrange
            User_Game userGame = new User_Game();
            int expected = 464;
            int actual;

            // Act
            userGame.user_game_id = expected;

            // Assert
            actual = userGame.user_game_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the user_id field
        public void User_GameTest_UserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            User_Game userGame = new User_Game();
            int expected = 344;
            int actual;

            // Act
            userGame.user_id = expected;

            // Assert
            actual = userGame.user_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the game_id field
        public void User_GameTest_GameIDWithCorrectType_ShouldPass()
        {
            // Arrange
            User_Game userGame = new User_Game();
            int expected = 43;
            int actual;

            // Act
            userGame.game_id = expected;

            // Assert
            actual = userGame.game_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the date_purchased field
        public void User_GameTest_DatePurchasedWithCorrectType_ShouldPass()
        {
            // Arrange
            User_Game UserGame = new User_Game();
            DateTime expected = new DateTime(2000, 1, 1);
            DateTime actual = new DateTime();

            // Act
            UserGame.date_purchased = expected;
            
            // Assert
            actual = UserGame.date_purchased;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the rating field
        public void User_GameTest_RatingWithCorrectType_ShouldPass()
        {
            // Arrange
            User_Game userGame = new User_Game();
            int expected = 43;
            int? actual;

            // Act
            userGame.rating = expected;

            // Assert
            actual = userGame.rating;
            Assert.AreEqual(expected, actual);
        }
    }
}
