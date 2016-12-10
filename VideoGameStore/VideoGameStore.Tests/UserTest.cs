/* Filename: UserTest.cs
 * Description: This class is responsible for unit testing for the User class.
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

namespace VideoGameStore.Tests
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void UserTest_UserConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            User user = new User();

            // Assert
            Assert.IsNotNull(user);
        }

        [Test]
        // This test is responsible for checking the user_id field
        public void UserTest_UserIDWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            int expected = 1;
            int actual;

            // Act
            user.user_id = expected;

            // Assert
            actual = user.user_id;        
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the username field
        public void UserTest_UsernameWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "CaptainWonderbar";
            string actual;

            // Act
            user.username = expected;

            // Assert
            actual = user.username;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the email field
        public void UserTest_EmailWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "CaptainWunderbar@wunderbar.com";
            string actual;

            // Act
            user.email = expected;

            // Assert
            actual = user.email;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the user_password field
        public void UserTest_PasswordWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "wunderbar23432";
            string actual;

            // Act
            user.user_password = expected;

            // Assert
            actual = user.user_password;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the login_failures field
        public void UserTest_LoginFailuresWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            int expected = 12;
            int actual;

            // Act
            user.login_failures = expected;

            // Assert
            actual = user.login_failures;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the first_name field
        public void UserTest_FirstNameWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "Gerrard";
            string actual;

            // Act
            user.first_name = expected;

            // Assert
            actual = user.first_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the last_name field
        public void UserTest_LastNameWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "Wunter";
            string actual;

            // Act
            user.last_name = expected;

            // Assert
            actual = user.last_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the phone field
        public void UserTest_PhoneNumberWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "(519) 555-5555";
            string actual;

            // Act
            user.phone = expected;

            // Assert
            actual = user.phone;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the gender field
        public void UserTest_GenderWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "M";
            string actual;

            // Act
            user.gender = expected;

            // Assert
            actual = user.gender;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the birthdate field
        public void UserTest_BirthDateWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            DateTime expected = new DateTime(2005, 3, 7);
            DateTime actual = new DateTime();

            // Act
            user.birthdate = expected;

            // Assert
            actual = user.birthdate;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the date_joined field
        public void UserTest_DateJoinedWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            DateTime expected = new DateTime(2010, 8, 9);
            DateTime actual = new DateTime();

            // Act
            user.date_joined = expected;

            // Assert
            actual = user.date_joined;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_member field
        public void UserTest_IsMemberWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            bool expected = true;
            bool actual;

            // Act
            user.is_member = expected;

            // Assert
            actual = user.is_member;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_inactive field
        public void UserTest_IsInactiveWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            bool expected = true;
            bool actual;

            // Act
            user.is_inactive = expected;

            // Assert
            actual = user.is_inactive;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_locked_out field
        public void UserTest_IsLockedOutWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            bool expected = true;
            bool actual;

            // Act
            user.is_locked_out = expected;

            // Assert
            actual = user.is_locked_out;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the is_on_email_list field
        public void UserTest_IsOnEmailListWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            bool expected = true;
            bool actual;

            // Act
            user.is_on_email_list = expected;
            
            // Assert
            actual = user.is_on_email_list;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the favorite_platform field
        public void UserTest_FavoritePlatformWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "PC";
            string actual;

            // Act
            user.favorite_platform = expected;
            
            // Assert
            actual = user.favorite_platform;        
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the favorite_category field
        public void UserTest_FavoriteCategoryWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "Horror";
            string actual;

            // Act
            user.favorite_category = expected;

            // Assert
            actual = user.favorite_category;        
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the notes field
        public void UserTest_NotesWithCorrectType_ShouldPass()
        {
            // Arrange
            User user = new User();
            string expected = "This is a note.";
            string actual;

            // Act
            user.notes = expected;

            // Assert
            actual = user.notes;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the First Name validation (value in lowercase characters)
        public void UserTest_Validation_FirstNameLowerCase_ShouldCapitalizeFirstLetter()
        {
            // Arrange
            User user = new User();
            string firstName = RPValidations.Capitalize("leroy", false);
            string expected = "Leroy";

            // Act
            user.first_name = firstName;

            // Assert
            string actual = user.first_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Last Name validation (value in lowercase characters)
        public void UserTest_Validation_LastNameLowerCase_ShouldCapitalizeFirstLetter()
        {
            // Arrange
            User user = new User();
            string lastName = RPValidations.Capitalize("jenkins", false);
            string expected = "Jenkins";

            // Act
            user.last_name = lastName;

            // Assert
            string actual = user.last_name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the Phone Number validation (value including dash delimiters)
        public void UserTest_Validation_PhoneNumberWithDashes_ShouldRemoveDashes()
        {
            // Arrange
            User user = new User();
            string phone = RPValidations.FormatPhoneNumber("000-000-0000");
            string expected = "0000000000";

            // Act
            user.phone = phone;

            // Assert
            string actual = user.phone;
            Assert.AreEqual(expected, actual);
        }            
    }
}
