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