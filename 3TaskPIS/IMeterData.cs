using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2TaskPIS {
    public interface IMeterData {
        string TypeResource { get; set; }
        DateTime Date { get; set; }
        double Value { get; set; }
        bool IsUsed { get; set; }

        string GetAllProperties();

        void SetFieldValues(string code);
    }
}


































//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace _2TaskPIS {
//    public abstract class MeterData {
//        public string typeResourse { get; set; }
//        public DateTime date { get; set; }
//        public double value { get; set; }
//        public bool isUsed { get; set; }


//        public MeterData() { }

//        public MeterData(string _type, DateTime _date, double _value) {
//            typeResourse = _type;
//            date = _date;
//            value = _value;
//        }

//        public virtual string GetAllProperties() {
//            string result = typeResourse + " " + date + " " + value + " " + isUsed;
//            return result;
//        }

//        public virtual void SetFieldValues(string code) {
//            code = code.Replace("'", "");
//            string[] dates = code.Split(';');

//            typeResourse = dates[0];
//            date = DateTime.ParseExact(dates[1], "yyyy.MM.dd", CultureInfo.InvariantCulture);
//            value = double.Parse(dates[2], CultureInfo.InvariantCulture);
//            isUsed = bool.Parse(dates[3]);
//        }
//    }
//}