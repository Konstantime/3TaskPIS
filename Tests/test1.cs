using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2TaskPIS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class test1 {
        [TestMethod]
        public void GetLinesCodesFromTextFileTestEmpty() {

            //arrange
            string path = "C:/Users/Kostya/OneDrive/Desktop/TestReader1.txt";
            var expected = new string[0];

            //act
            MeterDataReader meterDataReader = new MeterDataReader();
            var actual = meterDataReader.GetLinesCodesFromTextFile(path);

            //assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
        }
    }
}
