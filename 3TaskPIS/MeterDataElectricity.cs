using System;

namespace TaskPis2 {
    public class MeterDataElectricity : IMeterData {
        public string TypeResource { get; set; }
        public DateTime MeasurementDate { get; set; }
        public double Value { get; set; }
        public bool IsUsed { get; set; }
        public int NumberWatts { get; set; }
        public int Frequency { get; set; }
        public string Provider { get; set; }

        public MeterDataElectricity() { }

        public MeterDataElectricity(string type, DateTime date, double value, bool isUsed, int numberWatts, int frequency, string provider) {
            TypeResource = type;
            MeasurementDate = date;
            Value = value;
            IsUsed = isUsed;
            NumberWatts = numberWatts;
            Frequency = frequency;
            Provider = provider;
        }

        public void SetFieldValues(string code) {
            (MeasurementDate, Value, IsUsed, NumberWatts, Frequency, Provider) = DataProcessing.DefineTheseParametersForMeterDataElectricity(code);
            TypeResource = DataProcessing.DetermineTypeOfObjectFormatString(code);
        }

        public string GetPropertiesAsString() {
            return $"{TypeResource} {MeasurementDate.Day}.{MeasurementDate.Month}.{MeasurementDate.Year} {Value} {IsUsed} {NumberWatts} {Frequency} {Provider}";
        }

        // Переопределение метода Equals для проверки равенства по значениям свойств
        public override bool Equals(object obj) {
            if (obj is MeterDataElectricity other) {
                return TypeResource == other.TypeResource &&
                       MeasurementDate == other.MeasurementDate &&
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
            hash = hash * 31 + MeasurementDate.GetHashCode();
            hash = hash * 31 + Value.GetHashCode();
            hash = hash * 31 + IsUsed.GetHashCode();
            hash = hash * 31 + NumberWatts.GetHashCode();
            hash = hash * 31 + Frequency.GetHashCode();
            hash = hash * 31 + (Provider?.GetHashCode() ?? 0);

            return hash;
        }
    }
}