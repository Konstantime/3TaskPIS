using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _2TaskPIS;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void GetLinesCodesFromTextFileTestEmpty() {

            //arrange
            string path = "C:/Users/Kostya/OneDrive/Desktop/TestReader1.txt";
            var expected = new string[0];

            //act
            MeterDataReader meterDataReader = new MeterDataReader();
            var actual = meterDataReader.GetLinesCodesFromTextFile(path);

            //assert
            Assert.AreEqual(expected, actual);
            //Microsoft.VisualStudio.TestTools.UnitTesting.
        }
    }
}
