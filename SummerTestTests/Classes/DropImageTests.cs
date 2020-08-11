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
    public class DropImageTests
    {
        [TestMethod()]
        public void GetNameFromPathTest_ReturnsTrue()
        {
            //Arrange
            string path = "C:\\Users\\36\\Pictures\\GameCenter\\Warface\\Warface_sample.jpg";
            string actual = "Warface_sample.jpg";

            //Act
            string excected = DropImage.GetNameFromPath(path);

            //Assert
            Assert.AreEqual(excected,actual);
        }

        [TestMethod()]
        public void GetNameFromPathTest_ReturnsFalse()
        {
            //Arrange
            string path = "C:\\Users\\36\\Pictures\\GameCenter\\Warface\\Warface_s\\ample.jpg";
            string actual = "Warface_sample.jpg";

            //Act
            string excected = DropImage.GetNameFromPath(path);

            //Assert
            Assert.AreNotEqual(excected, actual);
        }
    }
}