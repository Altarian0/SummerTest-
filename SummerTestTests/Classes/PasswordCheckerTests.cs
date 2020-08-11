using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummerTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTest.Classes.Tests
{
    [TestClass()]
    public class PasswordCheckerTests
    {
        [TestMethod()]
        public void Check_Empty_ReturnsTrue()
        {
            // Arrange
            string password = "Ahmadag001@";
            bool expected = true;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_Empty_ReturnsFalse()
        {
            // Arrange
            string password = "";
            bool expected = false;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_6Symbols_ReturnsTrue()
        {
            // Arrange
            string password = "adKda3w#";
            bool expected = true;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_6Symbols_ReturnsFalse()
        {
            // Arrange
            string password = "dKd3#";
            bool expected = false;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_1UpperSymbols_ReturnsTrue()
        {
            // Arrange
            string password = "Adk5da$s";
            bool expected = true;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_1UpperSymbols_ReturnsFalse()
        {
            // Arrange
            string password = "adkdas";
            bool expected = false;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_Password_ReturnsTrue()
        {
            // Arrange
            string password = "quiNoA5#";
            bool expected = true;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_Password_ReturnsFalse()
        {
            // Arrange
            string password = "H$$29_64E";
            bool expected = false;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_Password_ReturnsTrue_2()
        {
            // Arrange
            string password = "fRo6Zn#";
            bool expected = true;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_Password_ReturnsFalse_2()
        {
            // Arrange
            string password = "151098";
            bool expected = false;

            //Act
            bool actual = PasswordValidateClass.CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(password);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}