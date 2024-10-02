using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2TaskPIS
{
    public class MeterDataWater: MeterData{
        public bool isСold { get; set; }
        public int quantity { get; set; }


        public MeterDataWater() { }

        public MeterDataWater(string _type, DateTime _date, double _value, bool _isUsed, bool _isСold, int _quantity) {
            typeResourse = _type;
            date = _date;
            value = _value;
            isUsed = _isUsed;
            isСold = _isСold;
            quantity = _quantity;
        }

        public override void SetFieldValues(string code) {
            code = code.Replace("'", "");
            string[] dates = code.Split(';');

            typeResourse = dates[0];
            date = DateTime.ParseExact(dates[1], "yyyy.MM.dd", CultureInfo.InvariantCulture);
            value = double.Parse(dates[2], CultureInfo.InvariantCulture);
            isUsed = bool.Parse(dates[3]);

            isСold = bool.Parse(dates[4]);
            quantity = int.Parse(dates[5], CultureInfo.InvariantCulture);
        }

        public override string GetAllProperties() {
            string result = typeResourse + " " + date + " " + value + " " + isUsed
                + " " + isСold + " " + quantity;
            return result;
        }
    }
}
