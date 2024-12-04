using System;

namespace _2TaskPIS {
    public class MeterDataWater : IMeterData {
        public string TypeResource { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public bool IsUsed { get; set; }
        public bool isCold { get; set; }
        public int quantity { get; set; }
        private DataProcessing dataProcessing = new DataProcessing();

        public MeterDataWater() { }

        public MeterDataWater(string type, DateTime date, double value, bool isUsed, bool isCold, int quantity) {
            TypeResource = type;
            this.Date = date;
            this.Value = value;
            this.IsUsed = isUsed;
            this.isCold = isCold;
            this.quantity = quantity;
        }

        public void SetFieldValues(string code) {
            (Date, Value, IsUsed, isCold, quantity) = dataProcessing.DefineTheseParametersForMeterDataWater(code);
            TypeResource = dataProcessing.DetermineTypeOfObjectFormatString(code);
        }

        public string GetAllProperties() {
            return $"{TypeResource} {Date.Day}.{Date.Month}.{Date.Year} {Value} {IsUsed} {isCold} {quantity}";
        }

        // Переопределение метода Equals для проверки равенства по значениям свойств
        public override bool Equals(object obj) {
            if (obj is MeterDataWater other) {
                return TypeResource == other.TypeResource &&
                       Date == other.Date &&
                       Value.Equals(other.Value) &&
                       IsUsed == other.IsUsed &&
                       isCold == other.isCold &&
                       quantity == other.quantity;
            }

            return false;
        }

        // Переопределение метода GetHashCode
        public override int GetHashCode() {
            // Простой способ комбинирования хеш-кодов свойств
            int hash = 17;
            hash = hash * 31 + (TypeResource?.GetHashCode() ?? 0);
            hash = hash * 31 + Date.GetHashCode();
            hash = hash * 31 + Value.GetHashCode();
            hash = hash * 31 + IsUsed.GetHashCode();
            hash = hash * 31 + isCold.GetHashCode();
            hash = hash * 31 + quantity.GetHashCode();

            return hash;
        }
    }
}