/* Filename: GameTest.cs
 * Description: This class is responsible for unit testing for the Game class.
 * 
 * Revision History:
 *      Greg Shalay 2016-10-27: Created Constructor and Field Tests
 *      Ryan Pease 2016-10-28: Created Validation Tests
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
    public class GameTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void GameTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Game game = new Game();

            Assert.IsNotNull(game);
        }

        [Test]
        // This test is responsible for checking the game_id field
        public void GameTest_GameIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            int expected = 24;
            int actual;

            // Act
            game.game_id = expected;

            // Assert
            actual = game.game_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the game_name field
        public void GameTest_GameNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            string expected = "Overwatch";
            string actual;

            // Act
            game.game_name = expected;

            // Assert
            actual = game.game_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the description field
        public void GameTest_DescriptionWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            string expected = "Overwatch is awesome!!!";
            string actual;

            // Act
            game.description = expected;

            // Assert
            actual = game.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the cost field
        public void GameTest_CostWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            decimal expected = 12;
            decimal actual;

            // Act
            game.cost = expected;

            // Assert
            actual = game.cost;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the list_price field
        public void GameTest_ListPriceWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            decimal expected = 89;
            decimal actual;

            // Act
            game.list_price = expected;

            // Assert
            actual = game.list_price;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the on_hand field
        public void GameTest_OnHandWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            int expected = 7;
            int actual;

            // Act
            game.on_hand = expected;

            // Assert
            actual = game.on_hand;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the developer_id field
        public void GameTest_DeveloperIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            int expected = 34;
            int actual;

            // Act
            game.developer_id = expected;

            // Assert
            actual = game.developer_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the publisher_id field
        public void GameTest_PublisherIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            int expected = 7;
            int actual;

            // Act
            game.publisher_id = expected;

            // Assert
            actual = game.publisher_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the genre_id field
        public void GameTest_GenreIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            int expected = 56;
            int actual;

            // Act
            game.genre_id = expected;

            // Assert
            actual = game.genre_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the release_date field
        public void GameTest_ReleaseDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            DateTime expected = new DateTime(2004, 2, 3);
            DateTime actual = new DateTime();

            // Act
            game.release_date = expected;

            // Assert
            actual = game.release_date;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_on_sale field
        public void GameTest_IsOnSaleWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            bool expected = false;
            bool actual;

            // Act
            game.is_on_sale = expected;

            // Assert
            actual = game.is_on_sale;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_discontinued field
        public void GameTest_IsDiscontinuedWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            bool expected = true;
            bool actual;

            // Act
            game.is_discontinued = expected;

            // Assert
            actual = game.is_discontinued;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_downloadable field
        public void GameTest_IsDownloadableWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            bool expected = false;
            bool actual;

            // Act
            game.is_downloadable = expected;

            // Assert
            actual = game.is_downloadable;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_physical_copy field
        public void GameTest_IsPhysicalCopyWithCorrectType_ShouldPass()
        {
            // Arrange
            Game game = new Game();
            bool expected = true;
            bool actual;

            // Act
            game.is_physical_copy = expected;

            // Assert
            actual = game.is_physical_copy;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Game Name validation (value in lowercase characters)
        public void GameTest_Validation_NameLowerCase_ShouldCapitalizeFirstLetters()
        {
            // Arrange
            Game game = new Game();
            string gameName = RPValidations.Capitalize("the legend of zelda", true);
            string expected = "The Legend Of Zelda";

            // Act
            game.game_name = gameName;

            // Assert
            string actual = game.game_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation (value in lowercase characters)
        public void GameTest_Validation_DescriptionLowerCase_ShouldCapitalizeFirstLetterOfEachSentence()
        {
            // Arrange
            Game game = new Game();
            string description = RPValidations.CapitalizeSentences("a game about a mysterious adventurer who wears green. he's on a mission to save princess zelda.");
            string expected = "A game about a mysterious adventurer who wears green. He's on a mission to save princess zelda.";

            // Act
            game.description = description;

            // Assert
            string actual = game.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation (value in uppercase characters)
        public void GameTest_Validation_DescriptionUpperCase_ShouldCapitalizeFirstLetterOfEachSentence()
        {
            // Arrange
            Game game = new Game();
            string description = RPValidations.CapitalizeSentences("A GAME ABOUT A MYSTERIOUS ADVENTURER WHO WEARS GREEN. HE'S ON A MISSION TO SAVE PRINCESS ZELDA.");
            string expected = "A game about a mysterious adventurer who wears green. He's on a mission to save princess zelda.";

            // Act
            game.description = description;

            // Assert
            string actual = game.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation on sentences containing a single word (value in lowercase characters)
        public void GameTest_Validation_DescriptionLowerCase_ShouldCapitalizeFirstLetterOfEachSentenceEvenSingleWordSentences()
        {
            // Arrange
            Game game = new Game();
            string description = RPValidations.CapitalizeSentences("something. something zelda. zelda.");
            string expected = "Something. Something zelda. Zelda.";

            // Act
            game.description = description;

            // Assert
            string actual = game.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation on sentences containing a single word (value in uppercase characters)
        public void GameTest_Validation_DescriptionUpperCase_ShouldCapitalizeFirstLetterOfEachSentenceEvenSingleWordSentences()
        {
            // Arrange
            Game game = new Game();
            string description = RPValidations.CapitalizeSentences("SOMETHING. SOMETHING ZELDA. ZELDA.");
            string expected = "Something. Something zelda. Zelda.";

            // Act
            game.description = description;

            // Assert
            string actual = game.description;
            Assert.AreEqual(expected, actual);
        }
    }
}
