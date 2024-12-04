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

        static MeterDataReader meterDataReader = new MeterDataReader();
        static DataProcessing dataProcessing = new DataProcessing();
        static void Main(string[] args) {  //  19   вариант 2

            List<IMeterData> meterDatas = CreateListMeterDatas("C:/Users/Kostya/OneDrive/Desktop/MeterData.txt");

            WritingAllValues(meterDatas);

            Console.ReadLine();
        }

        static private void WritingAllValues( List<IMeterData> meterDatas ) {
            foreach( var meterData in meterDatas ) {
                Console.WriteLine( meterData.GetAllProperties() );
            }
        }

        static public List<IMeterData> CreateListMeterDatas(string path) {
            string[] lines = meterDataReader.GetLinesCodesFromTextFile(path);
            List<IMeterData> meterDatas = new List<IMeterData>();

            TypeMeterData typeMeterData;
            for (int i = 0; i < lines.Length; i++) {
                if( dataProcessing.IsCorrectObject(lines[i]) == false) { continue; }

                typeMeterData = dataProcessing.DetermineTypeOfObject(lines[i]);

                if (GetMeterData(typeMeterData, lines[i]) != null) {
                    meterDatas.Add(GetMeterData(typeMeterData, lines[i]));
                }
            }

            return meterDatas;
        }

        static public IMeterData GetMeterData(TypeMeterData typeMeterData, string lineCode) {
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
    }
}