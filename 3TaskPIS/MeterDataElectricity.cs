using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2TaskPIS {
    public class MeterDataElectricity: MeterData {
        public int numberWatts { get; set; }
        public int frequency { get; set; }
        public string provider { get; set; }

        public MeterDataElectricity() { }

        public MeterDataElectricity(string _type, DateTime _date, double _value, bool _isUsed, int _numberWatts, int _frequency, string _provider) {
            typeResourse = _type;
            date = _date;
            value = _value;
            isUsed = _isUsed;
            numberWatts = _numberWatts;
            frequency = _frequency;
            provider = _provider;
        }

        public override void SetFieldValues(string code) {
            code = code.Replace("'", "");
            string[] dates = code.Split(';');

            typeResourse = dates[0];
            date = DateTime.ParseExact(dates[1], "yyyy.MM.dd", CultureInfo.InvariantCulture);
            value = double.Parse(dates[2], CultureInfo.InvariantCulture);
            isUsed = bool.Parse(dates[3]);

            numberWatts = int.Parse(dates[4], CultureInfo.InvariantCulture);
            frequency = int.Parse(dates[5], CultureInfo.InvariantCulture);
            provider = dates[6];
        }

        public override string GetAllProperties() {
            string result = typeResourse + " " + date + " " + value + " " + isUsed
                + " " + numberWatts + " " + frequency + " " + provider;
            return result;
        }
    }
}
