using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskPis2 {
    public interface IMeterData {
        string TypeResource { get; set; }
        DateTime MeasurementDate { get; set; }
        double Value { get; set; }
        bool IsUsed { get; set; }

        string GetPropertiesAsString();

        void SetFieldValues(string code);
    }
}