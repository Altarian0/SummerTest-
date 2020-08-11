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
    public class TimeHelperTests
    {
        [TestMethod()]
        public void SetTimeTest()
        {
            // Arrange
            string expected = DateTime.Now.ToString("m") + " " + DateTime.Now.ToString("yyyy") + " " + DateTime.Now.ToString("t");

            // Act
            string actual = TimeHelper.GetTime();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}