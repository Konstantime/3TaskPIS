//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using _2TaskPIS;
////using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace _3TaskPISTests;

//[TestClass]
//public class DataProcessingTests
//{
//    [TestMethod]
//    public void DetermineTypeOfObject(string codeObject) {
//        //arrange
//        string[] testingData = {
//            "'water'; 2024.12.10; 10.5; true; true; 90",
//            "'electro'; 2024.12.10; 10.5; true; 500; 50; Rusal",
//            "''; 2024.12.10; 10.5; true; 500; 50; Rusal",
//            "'electro'; ----; 10.5; true; 500; 50; Rusal",
//            "dbvjdbjvdjjd"
//        };
//        TypeMeterData[] expectedData = {
//            TypeMeterData.MeterDataWater,
//            TypeMeterData.MeterDataElectricity,
//            TypeMeterData.invalidType,
//            TypeMeterData.MeterDataElectricity,
//            TypeMeterData.invalidType
//        };

//        //act
//        DataProcessing dataProcessing = new DataProcessing();
//        TypeMeterData[] actualData = {
//            dataProcessing.DetermineTypeOfObject(testingData[0]),
//            dataProcessing.DetermineTypeOfObject(testingData[1]),
//            dataProcessing.DetermineTypeOfObject(testingData[2]),
//            dataProcessing.DetermineTypeOfObject(testingData[3]),
//            dataProcessing.DetermineTypeOfObject(testingData[4])
//        };

//        //assert
//        Assert.AreEqual(expectedData[0], actualData[0]);
//        Assert.AreEqual(expectedData[1], actualData[1]);
//        Assert.AreEqual(expectedData[2], actualData[2]);
//        Assert.AreEqual(expectedData[3], actualData[3]);
//        Assert.AreEqual(expectedData[4], actualData[4]);
//    }




//    [TestMethod]
//    [DataRow("water'2021.01.01';100.0;true", TypeMeterData.MeterDataWater)]
//    public void DetermineTypeOfObjectFormatStringTest(string codeObject) {
//        //arrange
//        string[] testingData = {
//            "'water'; 2024.12.10; 10.5; true; true; 90",
//            "'electro'; 2024.12.10; 10.5; true; 500; 50; Rusal",
//            "''; 2024.12.10; 10.5; true; 500; 50; Rusal",
//            "'electro'; ----; 10.5; true; 500; 50; Rusal",
//            "dbvjdbjvdjjd"
//        };



//        string[] expectedData = {
//            "water",
//            "electro",
//            "''; 2024.12.10; 10.5; true; 500; 50; Rusal",
//            "'electro'; ----; 10.5; true; 500; 50; Rusal",
//            "dbvjdbjvdjjd"
//        };

//        //act
//        DataProcessing dataProcessing = new DataProcessing();
//        string[] actualData = {
//            dataProcessing.DetermineTypeOfObjectFormatString(testingData[0]),
//            dataProcessing.DetermineTypeOfObjectFormatString(testingData[1]),
//            dataProcessing.DetermineTypeOfObjectFormatString(testingData[2]),
//            dataProcessing.DetermineTypeOfObjectFormatString(testingData[3]),
//            dataProcessing.DetermineTypeOfObjectFormatString(testingData[4])
//        };

//        //assert
//        Assert.AreEqual(expectedData[0], actualData[0]);
//        Assert.AreEqual(expectedData[1], actualData[1]);
//        Assert.AreEqual(expectedData[2], actualData[2]);
//        Assert.AreEqual(expectedData[3], actualData[3]);
//        Assert.AreEqual(expectedData[4], actualData[4]);
//    }


//    [TestMethod]
//    [DataRow("water'2021.01.01';100.0;true", TypeMeterData.MeterDataWater)]
//    [DataRow("electro'2021.01.01';150.5;false", TypeMeterData.MeterDataElectricity)]
//    public void DetermineTypeOfObject(string codeObject, TypeMeterData expectedType) {
//        // Arrange
//        var dataProcessing = new DataProcessing();

//        // Act
//        TypeMeterData actualType = dataProcessing.DetermineTypeOfObject(codeObject);

//        // Assert
//        Assert.AreEqual(expectedType, actualType);
//    }

//}
