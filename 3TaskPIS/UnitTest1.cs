using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskPis2;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.Generic;

namespace TaskPIS2Tests {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void CreatedCorrectMeterDataElectroTest() {
            IMeterData expected = new MeterDataElectricity("electro", 
                DateTime.ParseExact("2024.12.10", "yyyy.MM.dd", CultureInfo.InvariantCulture),
            10.5d, true, 500, 50, "Rusal");

            IMeterData actually = Program.GetMeterData(TypeMeterData.MeterDataElectricity, 
                "'electro';2024.12.10;10.5;true;500;50;Rusal");

            Assert.AreEqual(expected, actually);
        }

        [TestMethod]
        public void CreatedCorrectMeterDataWaterTest() {
            IMeterData expected = new MeterDataWater("water", 
                DateTime.ParseExact("2024.12.10", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                10.5d, true, true, 90);

            IMeterData actually = Program.GetMeterData(TypeMeterData.MeterDataWater, 
                "'water';2024.12.10;10.5;true;true;90");

            Assert.AreEqual(expected, actually);
        }

        [TestMethod]
        public void CorrectMeterDataWaterIsCorrectObjectTest() {
            var expected = true;
            
            bool actually = DataProcessing.IsCorrectObject("'water';2024.12.10;10.5;true;true;90");

            Assert.AreEqual(expected, actually);
        }

        [TestMethod]
        public void CorrectMeterDataElectricityIsCorrectObjectTest() {
            var expected = true;

            bool actually = DataProcessing.IsCorrectObject("'electro';2024.12.10;10.5;true;500;50;Rusal");

            Assert.AreEqual(expected, actually);
        }

        [TestMethod]
        public void IncorrectStringIsIncorrectObjectTest() {
            var expected = false;

            bool actually = DataProcessing.IsCorrectObject("dbvjdbjvdjjd");

            Assert.AreEqual(expected, actually);
        }
    }
}