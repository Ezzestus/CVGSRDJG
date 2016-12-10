/* Filename: Credit_CardTest.cs
 * Description: This class is responsible for unit testing for the Credit_Card class.
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
    public class Credit_CardTest
    {     
        [Test]
        // This test is responsible for checking the constructor
        public void Credit_CardTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Credit_Card creditCard = new Credit_Card();

            // Assert
            Assert.IsNotNull(creditCard);
        }

        [Test]
        // This test is responsible for checking the credit_card_id field
        public void Credit_CardTest_CreditCardIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Credit_Card creditCard = new Credit_Card();
            int expected = 9;
            int actual;

            // Act
            creditCard.credit_card_id = expected;

            // Assert
            actual = creditCard.credit_card_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the card_number field
        public void Credit_CardTest_CardNumberWithCorrectType_ShouldPass()
        {
            // Arrange
            Credit_Card creditCard = new Credit_Card();
            long expected = 9002332232323232;
            long actual;

            // Act
            creditCard.card_number = expected;

            // Assert
            actual = creditCard.card_number;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the expiry_date field
        public void Credit_CardTest_ExpiryDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Credit_Card creditCard = new Credit_Card();
            DateTime expected = new DateTime(2020, 1, 3);
            DateTime actual = new DateTime();

            // Act
            creditCard.expiry_date = expected;

            // Assert
            actual = creditCard.expiry_date;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the isExpired field
        public void Credit_CardTest_IsExpiredWithCorrectType_ShouldPass()
        {
            // Arrange
            Credit_Card creditCard = new Credit_Card();
            bool expected = false;
            bool actual;

            // Act
            creditCard.is_expired = expected;

            // Assert
            actual = creditCard.is_expired;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the isFlagged field
        public void Credit_CardTest_IsFlaggedWithCorrectType_ShouldPass()
        {
            // Arrange
            Credit_Card creditCard = new Credit_Card();
            bool expected = true;
            bool actual;

            // Act
            creditCard.is_flagged = expected;

            // Assert
            actual = creditCard.is_flagged;
            Assert.AreEqual(expected, actual);
        }
    }
}
