/* Filename: GenreTest.cs
 * Description: This class is responsible for unit testing for the Genre class.
 * 
 * Revision History:
 *      Greg Shalay 2016-10-27: Created constructor and field tests. 
 *      Ryan Pease 2016-10-31: Created validation tests.
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
    public class GenreTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void GenreTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Genre genre = new Genre();

            // Assert
            Assert.IsNotNull(genre);
        }

        [Test]
        // This test is responsible for checking the genre_id field
        public void GenreTest_GenreIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Genre genre = new Genre();
            int expected = 564;
            int actual;

            // Act
            genre.genre_id = expected;

            // Assert
            actual = genre.genre_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the genre_name field
        public void GenreTest_GenreNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Genre genre = new Genre();
            string expected = "Horror";
            string actual;

            // Act
            genre.genre_name = expected;

            // Assert
            actual = genre.genre_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the description field
        public void GenreTest_DescriptionWithCorrectType_ShouldPass()
        {
            // Arrange
            Genre genre = new Genre();
            string expected = "Games that focus on suspense and plot developement to entise their audience.";
            string actual;

            // Act
            genre.description = expected;

            // Assert
            actual = genre.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Genre Name validation (value in lowercase characters)
        public void GenreTest_Validation_NameLowerCase_ShouldCapitalizeFirstLetters()
        {
            // Arrange
            Genre genre = new Genre();
            string genreName = RPValidations.Capitalize("action", true);
            string expected = "Action";

            // Act
            genre.genre_name = genreName;

            // Assert
            string actual = genre.genre_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation (value in lowercase characters)
        public void GameTest_Validation_DescriptionLowerCase_ShouldCapitalizeFirstLetterOfEachSentence()
        {
            // Arrange
            Genre genre = new Genre();
            string description = RPValidations.CapitalizeSentences("a genre characterized by action. this genre is often dominated by movie spinoff games.");
            string expected = "A genre characterized by action. This genre is often dominated by movie spinoff games.";

            // Act
            genre.description = description;

            // Assert
            string actual = genre.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation (value in lowercase characters)
        public void GameTest_Validation_DescriptionUpperCase_ShouldCapitalizeFirstLetterOfEachSentence()
        {
            // Arrange
            Genre genre = new Genre();
            string description = RPValidations.CapitalizeSentences("A GENRE CHARACTERIZED BY ACTION. THIS GENRE IS OFTEN DOMINATED BY MOVIE SPINOFF GAMES.");
            string expected = "A genre characterized by action. This genre is often dominated by movie spinoff games.";

            // Act
            genre.description = description;

            // Assert
            string actual = genre.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation on sentences containing a single word (value in lowercase characters)
        public void GenreTest_Validation_DescriptionLowerCase_ShouldCapitalizeFirstLetterOfEachSentenceEvenSingleWordSentences()
        {
            // Arrange
            Genre genre = new Genre();
            string description = RPValidations.CapitalizeSentences("action. action and adventure. platform.");
            string expected = "Action. Action and adventure. Platform.";

            // Act
            genre.description = description;

            // Assert
            string actual = genre.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation on sentences containing a single word (value in uppercase characters)
        public void GenreTest_Validation_DescriptionUpperCase_ShouldCapitalizeFirstLetterOfEachSentenceEvenSingleWordSentences()
        {
            // Arrange
            Genre genre = new Genre();
            string description = RPValidations.CapitalizeSentences("ACTION. ACTION AND ADVENTURE. PLATFORM.");
            string expected = "Action. Action and adventure. Platform.";

            // Act
            genre.description = description;

            // Assert
            string actual = genre.description;
            Assert.AreEqual(expected, actual);
        }
    }
}
