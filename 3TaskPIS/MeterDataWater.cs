using System;

namespace TaskPis2 {
    public class MeterDataWater : IMeterData {
        public string TypeResource { get; set; }
        public DateTime MeasurementDate { get; set; }
        public double Value { get; set; }
        public bool IsUsed { get; set; }
        public bool IsCold { get; set; }
        public int Quantity { get; set; }

        public MeterDataWater() { }

        public MeterDataWater(string type, DateTime date, double value, bool isUsed, bool isCold, int quantity) {
            TypeResource = type;
            this.MeasurementDate = date;
            this.Value = value;
            this.IsUsed = isUsed;
            this.IsCold = isCold;
            this.Quantity = quantity;
        }

        public void SetFieldValues(string code) {
            (MeasurementDate, Value, IsUsed, IsCold, Quantity) = DataProcessing.DefineTheseParametersForMeterDataWater(code);
            TypeResource = DataProcessing.DetermineTypeOfObjectFormatString(code);
        }

        public string GetPropertiesAsString() {
            return $"{TypeResource} {MeasurementDate.Day}.{MeasurementDate.Month}.{MeasurementDate.Year} {Value} {IsUsed} {IsCold} {Quantity}";
        }

        // Переопределение метода Equals для проверки равенства по значениям свойств
        public override bool Equals(object obj) {
            if (obj is MeterDataWater other) {
                return TypeResource == other.TypeResource &&
                       MeasurementDate == other.MeasurementDate &&
                       Value.Equals(other.Value) &&
                       IsUsed == other.IsUsed &&
                       IsCold == other.IsCold &&
                       Quantity == other.Quantity;
            }

            return false;
        }

        // Переопределение метода GetHashCode
        public override int GetHashCode() {
            // Простой способ комбинирования хеш-кодов свойств
            int hash = 17;
            hash = hash * 31 + (TypeResource?.GetHashCode() ?? 0);
            hash = hash * 31 + MeasurementDate.GetHashCode();
            hash = hash * 31 + Value.GetHashCode();
            hash = hash * 31 + IsUsed.GetHashCode();
            hash = hash * 31 + IsCold.GetHashCode();
            hash = hash * 31 + Quantity.GetHashCode();

            return hash;
        }
    }
}