using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Globalization;
using _2TaskPIS;

namespace ProgramTests {
    public class Tests {

        [Test]
        public void Test2() {
            Assert.Pass();
        }


        [Test]
        public void CreatedCorrectMeterDataElectroTest() {
            IMeterData expected = new MeterDataElectricity("electro", DateTime.ParseExact("2024.12.10", "yyyy.MM.dd", CultureInfo.InvariantCulture),
            10.5d, true, 500, 50, "Rusal");

            IMeterData actually = Program.GetMeterData(TypeMeterData.MeterDataElectricity, "'electro';2024.12.10;10.5;true;500;50;Rusal");
            Program.

            Assert.AreEqual(expected, actually);
        }
    }
}