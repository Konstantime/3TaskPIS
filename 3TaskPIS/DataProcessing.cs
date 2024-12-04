using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2TaskPIS {
    public class DataProcessing {
        private (DateTime, double, bool) DefineStandardParametersMeterData(string code) {
            code = code.Replace("'", "");
            string[] dates = code.Split(';');

            if (dates.Length < 4) {
                throw new FormatException("Неверный формат кода: недостаточно частей для разбора.");
            }

            DateTime date = DateTime.Today;
            double value = 0d;
            bool isUsed = false;

            try {
                date = DateTime.ParseExact(dates[1], "yyyy.MM.dd", CultureInfo.InvariantCulture);
            }
            catch { date = DateTime.Today; }

            try {
                value = double.Parse(dates[2], CultureInfo.InvariantCulture);
            }
            catch { value = 0d; }

            try { isUsed = bool.Parse(dates[3]); }
            catch { isUsed = false; }

            return (date, value, isUsed);
        }

        public (DateTime, double, bool, int, int, string) DefineTheseParametersForMeterDataElectricity(string code) {
            if (string.IsNullOrWhiteSpace(code)) {
                throw new ArgumentNullException(nameof(code), "Код не должен быть null или пустым.");
            }

            code = code.Replace("'", "");
            string[] dates = code.Split(';');

            if (dates.Length < 7) {
                throw new FormatException("Неверный формат кода: недостаточно частей для разбора.");
            }
            
            var (date, value, isUsed) = DefineStandardParametersMeterData(code);

            int numberWatts = int.Parse(dates[4], CultureInfo.InvariantCulture);
            int frequency = int.Parse(dates[5], CultureInfo.InvariantCulture);
            string provider = dates[6];

            return (date, value, isUsed, numberWatts, frequency, provider);
        }

        public bool IsCorrectObject(string codeObject) {
            if (AssumeTypeOfObject(codeObject) == TypeMeterData.invalidType) {
                return false;
            }
            return true;
        }

        public (DateTime, double, bool, bool, int) DefineTheseParametersForMeterDataWater(string code) {
            code = code.Replace("'", "");
            string[] dates = code.Split(';');

            var (date, value, isUsed) = DefineStandardParametersMeterData(code);

            bool isСold = bool.Parse(dates[4]);
            int quantity = int.Parse(dates[5], CultureInfo.InvariantCulture);

            return (date, value, isUsed, isСold, quantity);
        }

        public TypeMeterData DetermineTypeOfObject(string codeObject) {
            if (string.IsNullOrWhiteSpace(codeObject)) {
                throw new ArgumentNullException(nameof(codeObject), "Строка не должна быть null или пустой.");
            }

            var (indexFirstForging, indexLastForging) = DefineQuotationMarkIndexes(codeObject);

            try {
                string typeResourse = codeObject.Substring(indexFirstForging + 1,
                    indexLastForging - indexFirstForging - 1);

                switch (typeResourse) {
                    case "water":
                        return TypeMeterData.MeterDataWater;
                    case "electro":
                        return TypeMeterData.MeterDataElectricity;
                    default:
                        return TypeMeterData.invalidType;
                }
            }
            catch (ArgumentNullException ex) {
                throw new ArgumentNullException($"Ошибка: {ex.Message}");
            }
            catch (FormatException ex) {
                throw new FormatException($"Ошибка формата: {ex.Message}");
            }
            catch (Exception ex) {
                throw new Exception($"Произошла ошибка: {ex.Message}");
            }
        }

        public TypeMeterData AssumeTypeOfObject(string codeObject) {
            if (codeObject.Split(';').Length - 1 == 6) {
                return TypeMeterData.MeterDataElectricity;
            }
            else if (codeObject.Split(';').Length - 1 == 5) {
                return TypeMeterData.MeterDataWater;
            }
            return TypeMeterData.invalidType;
        }

        public string DetermineTypeOfObjectFormatString(string codeObject) {
            if (string.IsNullOrWhiteSpace(codeObject)) {
                throw new ArgumentNullException(nameof(codeObject), "Строка не должна быть null или пустой.");
            }

            var (indexFirstForging, indexLastForging) = DefineQuotationMarkIndexes(codeObject);

            try {
                string typeResourse = codeObject.Substring(indexFirstForging + 1,
                    indexLastForging - indexFirstForging - 1);

                return typeResourse;
            }
            catch (ArgumentNullException ex) {
                throw new ArgumentNullException($"Ошибка: {ex.Message}");
            }
            catch (FormatException ex) {
                throw new FormatException($"Ошибка формата: {ex.Message}");
            }
            catch (Exception ex) {
                throw new Exception($"Произошла ошибка: {ex.Message}");
            }
        }

        private (int indexFirstForging, int indexLastForging) DefineQuotationMarkIndexes(string codeObject) {
            int indexFirstForging = codeObject.IndexOf("'");
            if (indexFirstForging == -1) {
                throw new FormatException("Не найдена первая кавычка в строке.");
            }

            int indexLastForging = codeObject.IndexOf("'", indexFirstForging + 1);
            if (indexLastForging == -1) {
                throw new FormatException("Не найдена вторая кавычка в строке.");
            }

            return (indexFirstForging, indexLastForging);
        }

    }
}