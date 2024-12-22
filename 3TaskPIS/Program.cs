using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TaskPis2 {
    public enum TypeMeterData {
        MeterData,
        MeterDataElectricity,
        MeterDataWater,
        InvalidType
    }
    internal class Program {
        static void Main() {  //  19   вариант 2

            List<IMeterData> meterDatas = CreateListMeterDatas("C:/Users/Kostya/OneDrive/Desktop/MeterData.txt");

            WritingAllValues(meterDatas);

            Console.ReadLine();
        }

        static private void WritingAllValues( List<IMeterData> meterDatas ) {
            foreach( var meterData in meterDatas ) {
                Console.WriteLine( meterData.GetPropertiesAsString() );
            }
        }

        static public List<IMeterData> CreateListMeterDatas(string path) {
            string[] lines = MeterDataReader.GetLinesCodesFromTextFile(path);
            List<IMeterData> meterDatas = new List<IMeterData>();

            TypeMeterData typeMeterData;
            for (int i = 0; i < lines.Length; i++) {
                if( DataProcessing.IsCorrectObject(lines[i]) == false) { continue; }

                typeMeterData = DataProcessing.DetermineTypeOfObject(lines[i]);

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