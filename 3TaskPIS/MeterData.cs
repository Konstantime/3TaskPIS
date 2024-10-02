using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2TaskPIS {
    public abstract class MeterData {
        public string typeResourse { get; set; }
        public DateTime date { get; set; }
        public double value { get; set; }
        public bool isUsed { get; set; } 


        public MeterData() { }

        public MeterData(string _type, DateTime _date, double _value) {
            typeResourse = _type;
            date = _date;
            value = _value;
        }

        public virtual string GetAllProperties() {
            string result = typeResourse + " " + date + " " +  value + " " + isUsed;
            return result;
        }

        public virtual void SetFieldValues(string code) {
            code = code.Replace("'", "");
            string[] dates = code.Split(';');

            typeResourse = dates[0];
            date = DateTime.ParseExact(dates[1], "yyyy.MM.dd", CultureInfo.InvariantCulture);
            value = double.Parse(dates[2], CultureInfo.InvariantCulture);
            isUsed = bool.Parse(dates[3]);
        }

        public void print(Stream stream) {
            byte[] bytes = Encoding.UTF8.GetBytes(typeResourse);
            stream.Write(bytes, 0, bytes.Length);

            bytes = Encoding.UTF8.GetBytes(Convert.ToString(date));
            stream.Write(bytes, 0, bytes.Length);

            bytes = Encoding.UTF8.GetBytes(Convert.ToString(value));
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}