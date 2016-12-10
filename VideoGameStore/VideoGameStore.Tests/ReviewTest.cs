/* Filename: ReviewTest.cs
 * Description: This class is responsible for unit testing for the Review class.
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
    public class ReviewTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void ReviewTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Review review = new Review();

            // Assert
            Assert.IsNotNull(review);
        }

        [Test]
        // This test is responsible for checking the review_id field
        public void ReviewTest_ReviewIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Review review = new Review();
            int expected = 51;
            int actual;

            // Act
            review.review_id = expected;
            actual = review.review_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the user_id field
        public void ReviewTest_UserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Review review = new Review();
            int expected = 51;
            int actual;

            // Act
            review.user_id = expected;
            actual = review.user_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the game_id field
        public void ReviewTest_GameIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Review review = new Review();
            int expected = 28;
            int actual;

            // Act
            review.game_id = expected;
            actual = review.game_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the review_date field
        public void ReviewTest_ReviewDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Review review = new Review();
            DateTime expected = new DateTime(2003, 2, 1);
            DateTime actual = new DateTime();

            // Act
            review.review_date = expected;
            actual = review.review_date;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_approved field
        public void ReviewTest_IsApprovedWithCorrectType_ShouldPass()
        {
            // Arrange
            Review review = new Review();
            bool expected = true;
            bool actual;

            // Act
            review.is_approved = expected;
            actual = review.is_approved;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_deleted field
        public void ReviewTest_IsDeletedWithCorrectType_ShouldPass()
        {
            // Arrange
            Review review = new Review();
            bool expected = true;
            bool actual;

            // Act
            review.is_deleted = expected;

            // Assert
            actual = review.is_deleted;
            Assert.AreEqual(expected, actual);
        }
    }
}
