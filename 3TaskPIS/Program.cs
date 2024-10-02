using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TypeMeterData
{
    MeterData,
    MeterDataElectricity,
    MeterDataWater,
    invalidType
}

namespace _2TaskPIS {
    internal class Program {
        static void Main(string[] args) {  //  19   вариант 2

            List<MeterData> meterDatas = CreateListMeterDatas();

            WritingAllValues(meterDatas);

            Console.ReadLine();
        }

        static private void WritingAllValues( List<MeterData> meterDatas ) {
            foreach( var meterData in meterDatas ) {
                Console.WriteLine( meterData.GetAllProperties() );
            }
        }

        static private List<MeterData> CreateListMeterDatas() {
            string[] lines = GetLinesCodesFromTextFile("C:/Users/Kostya/OneDrive/Desktop/MeterData.txt");
            List<MeterData> meterDatas = new List<MeterData>();

            TypeMeterData typeMeterData;
            for (int i = 0; i < lines.Length; i++) {
                typeMeterData = DetermineTypeOfObject(lines[i]);

                if (GetMeterData(typeMeterData, lines[i]) != null) {
                    meterDatas.Add(GetMeterData(typeMeterData, lines[i]));
                }
            }

            return meterDatas;
        }

        static private MeterData GetMeterData(TypeMeterData typeMeterData, string lineCode) {
            switch (typeMeterData) {
                case TypeMeterData.MeterDataWater:
                    var meterDataWater = new MeterDataWater();
                    meterDataWater.SetFieldValues(lineCode);
                    return meterDataWater;

                case TypeMeterData.MeterDataElectricity:
                    var meterDataElectricity = new MeterDataElectricity();
                    meterDataElectricity.SetFieldValues(lineCode);
                    return meterDataElectricity;

                default:
                    return null;
            }
        }

        static private string[] GetLinesCodesFromTextFile(string filePath) {
            string fileContent = GetTextFromFile(filePath);

            string[] result = fileContent.Split('\r');

            return result;
        }

        static private string GetTextFromFile(string filePath) {
            try {
                using (StreamReader reader = new StreamReader(filePath)) {
                    return reader.ReadToEnd();
                }
            }
            catch (IOException ex) {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return null;
            }
        }

        static private TypeMeterData DetermineTypeOfObject(string codeObject) {
            string typeResourse = GetTypeFromString(codeObject);
            switch (typeResourse) {
                case "water":
                    return TypeMeterData.MeterDataWater;
                case "electro":
                    return TypeMeterData.MeterDataElectricity;
                default:
                    return TypeMeterData.invalidType;
            }
        }

        static private string GetTypeFromString(string codeObject) {

            int indexFirstForging = codeObject.IndexOf("'");
            int indexLastForging = codeObject.IndexOf("'", indexFirstForging + 1);

            return codeObject.Substring(indexFirstForging + 1, indexLastForging - indexFirstForging - 1);

        }
    }
}