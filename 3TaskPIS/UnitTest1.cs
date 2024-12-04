using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _2TaskPIS;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.Generic;

namespace _2TaskPISTests {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void CreatedCorrectMeterDataElectroTest() {
            IMeterData expected = new MeterDataElectricity("electro", DateTime.ParseExact("2024.12.10", "yyyy.MM.dd", CultureInfo.InvariantCulture),
            10.5d, true, 500, 50, "Rusal");

            IMeterData actually = Program.GetMeterData(TypeMeterData.MeterDataElectricity, "'electro';2024.12.10;10.5;true;500;50;Rusal");

            Assert.AreEqual(expected, actually);
        }

        [TestMethod]
        public void CreatedCorrectMeterDataWaterTest() {
            IMeterData expected = new MeterDataWater("water", DateTime.ParseExact("2024.12.10", "yyyy.MM.dd", CultureInfo.InvariantCulture),
                10.5d, true, true, 90);

            IMeterData actually = Program.GetMeterData(TypeMeterData.MeterDataWater, "'water';2024.12.10;10.5;true;true;90");

            Assert.AreEqual(expected, actually);
        }

        [TestMethod]
        public void CorrectMeterDataWaterIsCorrectObjectTest() {
            DataProcessing dataProcessing = new DataProcessing();
            var expected = true;

            bool actually = dataProcessing.IsCorrectObject("'water';2024.12.10;10.5;true;true;90");

            Assert.AreEqual(expected, actually);

            
        }
        [TestMethod]
        public void CorrectMeterDataElectricityIsCorrectObjectTest() {
            DataProcessing dataProcessing = new DataProcessing();
            var expected = true;

            bool actually = dataProcessing.IsCorrectObject("'electro';2024.12.10;10.5;true;500;50;Rusal");

            Assert.AreEqual(expected, actually);
        }

        [TestMethod]
        public void EmptyStringIsIncorrectObjectTest() {
            DataProcessing dataProcessing = new DataProcessing();
            var expected = false;

            bool actually = dataProcessing.IsCorrectObject("");

            Assert.AreEqual(expected, actually);
        }

        [TestMethod]
        public void IncorrectStringIsIncorrectObjectTest() {
            DataProcessing dataProcessing = new DataProcessing();
            var expected = false;

            bool actually = dataProcessing.IsCorrectObject("dbvjdbjvdjjd");

            Assert.AreEqual(expected, actually);
        }
    }
}
