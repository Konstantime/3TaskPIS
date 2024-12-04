using System;

namespace _2TaskPIS {
    public class MeterDataElectricity : IMeterData {
        public string TypeResource { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public bool IsUsed { get; set; }
        public int NumberWatts { get; set; }
        public int Frequency { get; set; }
        public string Provider { get; set; }
        private DataProcessing dataProcessing = new DataProcessing();

        // Конструктор по умолчанию
        public MeterDataElectricity() { }

        // Конструктор с параметрами
        public MeterDataElectricity(string type, DateTime date, double value, bool isUsed, int numberWatts, int frequency, string provider) {
            TypeResource = type;
            Date = date;
            Value = value;
            IsUsed = isUsed;
            NumberWatts = numberWatts;
            Frequency = frequency;
            Provider = provider;
        }

        public void SetFieldValues(string code) {
            (Date, Value, IsUsed, NumberWatts, Frequency, Provider) = dataProcessing.DefineTheseParametersForMeterDataElectricity(code);
            TypeResource = dataProcessing.DetermineTypeOfObjectFormatString(code);
        }

        public string GetAllProperties() {
            return $"{TypeResource} {Date.Day}.{Date.Month}.{Date.Year} {Value} {IsUsed} {NumberWatts} {Frequency} {Provider}";
        }

        // Переопределение метода Equals для проверки равенства по значениям свойств
        public override bool Equals(object obj) {
            if (obj is MeterDataElectricity other) {
                return TypeResource == other.TypeResource &&
                       Date == other.Date &&
                       Value.Equals(other.Value) &&
                       IsUsed == other.IsUsed &&
                       NumberWatts == other.NumberWatts &&
                       Frequency == other.Frequency &&
                       Provider == other.Provider;
            }

            return false;
        }

        // Переопределение метода GetHashCode
        public override int GetHashCode() {
            // Комбинирование хеш-кодов свойств
            int hash = 17;
            hash = hash * 31 + (TypeResource?.GetHashCode() ?? 0);
            hash = hash * 31 + Date.GetHashCode();
            hash = hash * 31 + Value.GetHashCode();
            hash = hash * 31 + IsUsed.GetHashCode();
            hash = hash * 31 + NumberWatts.GetHashCode();
            hash = hash * 31 + Frequency.GetHashCode();
            hash = hash * 31 + (Provider?.GetHashCode() ?? 0);

            return hash;
        }
    }
}