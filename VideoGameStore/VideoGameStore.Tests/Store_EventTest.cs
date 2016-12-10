/* Filename: Store_EventTest.cs
 * Description: This class is responsible for unit testing for the Store_Event class.
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
    public class Store_EventTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void Store_Event_Test_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Store_Event storeEvent = new Store_Event();

            // Assert
            Assert.IsNotNull(storeEvent);
        }

        [Test]
        // This test is responsible for checking the store_event_id field
        public void Store_Event_Test_StoreEventIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            int expected = 76;
            int actual;

            // Act
            storeEvent.store_event_id = expected;

            // Assert
            actual = storeEvent.store_event_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the store_event_name field
        public void Store_Event_Test_StoreEventNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            string expected = "Friday Night Gaming";
            string actual;

            // Act
            storeEvent.store_event_name = expected;

            // Assert
            actual = storeEvent.store_event_name;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        // This test is responsible for checking the description field
        public void Store_Event_Test_DescriptionWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            string expected = "Friday Night Gaming is awesome!";
            string actual;

            // Act
            storeEvent.description = expected;

            // Assert
            actual = storeEvent.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the address_id field
        public void Store_Event_Test_AddressIDWithCorrectType_ShouldPass()
        {
            Store_Event storeEvent = new Store_Event();
            int expected = 98;
            int actual;

            // Act
            storeEvent.address_id = expected;

            // Assert
            actual = storeEvent.address_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the start_date field
        public void Store_Event_Test_StartDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            DateTime expected = new DateTime(1997, 12, 27);
            DateTime actual = new DateTime();

            // Act
            storeEvent.start_date = expected;

            // Assert
            actual = storeEvent.start_date;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the end_date field
        public void Store_Event_Test_EndDateWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            DateTime expected = new DateTime(1997, 12, 29);
            DateTime actual = new DateTime();

            // Act
            storeEvent.end_date = expected;

            // Assert
            actual = storeEvent.end_date;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the max_registrants field
        public void Store_Event_Test_MaxRegistrantsWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            int expected = 2000;
            int actual;

            // Act
            storeEvent.max_registrants = expected;

            // Assert
            actual = storeEvent.max_registrants;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the if_full field
        public void Store_Event_Test_IsFullWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            bool expected = false;
            bool actual;

            // Act
            storeEvent.is_full = expected;

            // Assert
            actual = storeEvent.is_full;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_members_only field
        public void Store_Event_Test_IsMembersOnlyWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            bool expected = true;
            bool actual;

            // Act
            storeEvent.is_members_only = expected;

            // Assert
            actual = storeEvent.is_members_only;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_cancelled field
        public void Store_Event_Test_IsCancelledWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            bool expected = false;
            bool actual;

            // Act
            storeEvent.is_cancelled = expected;

            // Assert
            actual = storeEvent.is_cancelled;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Store Event Name validation (value in lowercase characters)
        public void Store_EventTest_Validation_NameLowerCase_ShouldCapitalizeFirstLetters()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            string eventName = RPValidations.Capitalize("best sale ever", true);
            string expected = "Best Sale Ever";

            // Act
            storeEvent.store_event_name = eventName;

            // Assert
            string actual = storeEvent.store_event_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation (value in lowercase characters)
        public void Store_EventTest_Validation_DescriptionLowerCase_ShouldCapitalizeFirstLetterOfEachSentence()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            string description = RPValidations.CapitalizeSentences("a sale for all of our customers. it's our chance to pay you back for your loyalty.");
            string expected = "A sale for all of our customers. It's our chance to pay you back for your loyalty.";

            // Act
            storeEvent.description = description;

            // Assert
            string actual = storeEvent.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation (value in uppercase characters)
        public void Store_EventTest_Validation_DescriptionUpperCase_ShouldCapitalizeFirstLetterOfEachSentence()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            string description = RPValidations.CapitalizeSentences("A SALE FOR ALL OF OUR CUSTOMERS. IT'S OUR CHANCE TO PAY YOU BACK FOR YOUR LOYALTY.");
            string expected = "A sale for all of our customers. It's our chance to pay you back for your loyalty.";

            // Act
            storeEvent.description = description;

            // Assert
            string actual = storeEvent.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation on sentences containing a single word (value in lowercase characters)
        public void Store_EventTest_Validation_DescriptionLowerCase_ShouldCapitalizeFirstLetterOfEachSentenceEvenSingleWordSentences()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            string description = RPValidations.CapitalizeSentences("biggest. biggest sale. ever");
            string expected = "Biggest. Biggest sale. Ever.";

            // Act
            storeEvent.description = description;

            // Assert
            string actual = storeEvent.description;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Description validation on sentences containing a single word (value in uppercase characters)
        public void Store_EventTest_Validation_DescriptionUpperCase_ShouldCapitalizeFirstLetterOfEachSentenceEvenSingleWordSentences()
        {
            // Arrange
            Store_Event storeEvent = new Store_Event();
            string description = RPValidations.CapitalizeSentences("BIGGEST. BIGGEST SALE. EVER");
            string expected = "Biggest. Biggest sale. Ever.";

            // Act
            storeEvent.description = description;

            // Assert
            string actual = storeEvent.description;
            Assert.AreEqual(expected, actual);
        }
    }
}
