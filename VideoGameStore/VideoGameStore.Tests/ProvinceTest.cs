/* Filename: Employee_AddressTest.cs
 * Description: This class is responsible for unit testing for the Employee_Address class.
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
    public class ProvinceTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void ProvinceTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Province province = new Province();

            // Assert
            Assert.IsNotNull(province);
        }

        [Test]
        // This test is responsible for checking the province_id field
        public void ProvinceTest_ProvinceIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Province province = new Province();
            int expected = 7;
            int actual;

            // Act
            province.province_id = expected;

            // Assert
            actual = province.province_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the province_code field
        public void ProvinceTest_ProvinceCodeWithCorrectType_ShouldPass()
        {
            // Arrange
            Province province = new Province();
            string expected = "ON";
            string actual;

            // Act
            province.province_code = expected;

            // Assert
            actual = province.province_code;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the province_name field
        public void ProvinceTest_ProvinceNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Province province = new Province();
            string expected = "Ontario";
            string actual;

            // Act
            province.province_name = expected;

            // Assert
            actual = province.province_name;
            Assert.AreEqual(expected, actual);
        }
    }
}
