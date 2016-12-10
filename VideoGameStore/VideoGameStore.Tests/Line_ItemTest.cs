/* Filename: Line_ItemTest.cs
 * Description: This class is responsible for unit testing for the Line_Item class.
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
    public class Line_ItemTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void Line_ItemTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Line_Item lineItem = new Line_Item();

            // Assert
            Assert.IsNotNull(lineItem);
        }

        [Test]
        // This test is responsible for checking the line_item_id field
        public void Line_ItemTest_LineItemIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Line_Item lineItem = new Line_Item();
            int expected = 67;
            int actual;

            // Act
            lineItem.line_item_id = expected;

            // Assert
            actual = lineItem.line_item_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the invoice_id field
        public void Line_ItemTest_InvoiceIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Line_Item lineItem = new Line_Item();
            int expected = 67;
            int actual;

            // Act
            lineItem.invoice_id = expected;

            // Assert
            actual = lineItem.invoice_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the game_id field
        public void Line_ItemTest_GameIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Line_Item lineItem = new Line_Item();
            int expected = 5;
            int actual;

            // Act
            lineItem.game_id = expected;

            // Assert
            actual = lineItem.game_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the quantity field
        public void Line_ItemTest_QuantityWithCorrectType_ShouldPass()
        {
            // Arrange
            Line_Item lineItem = new Line_Item();
            int expected = 2;
            int actual;

            // Act
            lineItem.quantity = expected;

            // Assert
            actual = lineItem.quantity;
            Assert.AreEqual(expected, actual);
        }
    }
}
