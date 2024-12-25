using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskPis2 {
    /// <summary>
    ///   <br />
    /// </summary>
    static public class DataProcessing {
        /// <summary>Defines the standard parameters meter data.</summary>
        /// <param name="code">The code.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.FormatException">Неверный формат кода: недостаточно частей для разбора.</exception>
        static private (DateTime, double, bool) DefineStandardParametersMeterData(string code) {
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
            catch (ArgumentNullException) { date = DateTime.Today; }
            catch (FormatException) { date = DateTime.Today; }

            try {
                value = double.Parse(dates[2], CultureInfo.InvariantCulture);
            }
            catch(ArgumentNullException) { value = 0d; }
            catch (FormatException) { value = 0d; }

            try { isUsed = bool.Parse(dates[3]); }
            catch (ArgumentNullException) { isUsed = false; }
            catch (FormatException) { isUsed = false; }

            return (date, value, isUsed);
        }

        /// <summary>Defines the these parameters for meter data electricity.</summary>
        /// <param name="code">The code.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">code - Код не должен быть null или пустым.</exception>
        /// <exception cref="System.FormatException">Неверный формат кода: недостаточно частей для разбора.</exception>
        static public (DateTime, double, bool, int, int, string) DefineTheseParametersForMeterDataElectricity(string code) {
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

        static public bool IsCorrectObject(string codeObject) {
            if (AssumeTypeOfObject(codeObject) == TypeMeterData.InvalidType) {
                return false;
            }
            return true;
        }

        /// <summary>Defines the these parameters for meter data water.</summary>
        /// <param name="code">The code.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">code - The 'code' parameter cannot be null or empty.</exception>
        static public (DateTime, double, bool, bool, int) DefineTheseParametersForMeterDataWater(string code) {
            if (string.IsNullOrEmpty(code)) {
                throw new ArgumentNullException(nameof(code), "The 'code' parameter cannot be null or empty.");
            }

            code = code.Replace("'", "");
            string[] dates = code.Split(';');

            var (date, value, isUsed) = DefineStandardParametersMeterData(code);

            bool isСold = bool.Parse(dates[4]);
            int quantity = int.Parse(dates[5], CultureInfo.InvariantCulture);

            return (date, value, isUsed, isСold, quantity);
        }

        /// <summary>Determines the type of object.</summary>
        /// <param name="codeObject">The code object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">codeObject - Строка не должна быть null или пустой.
        /// or
        /// Ошибка: {ex.Message}</exception>
        /// <exception cref="System.FormatException">Ошибка формата: {ex.Message}</exception>
        static public TypeMeterData DetermineTypeOfObject(string codeObject) {
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
                        return TypeMeterData.InvalidType;
                }
            }
            catch (ArgumentNullException ex) {
                throw new ArgumentNullException($"Ошибка: {ex.Message}");
            }
            catch (FormatException ex) {
                throw new FormatException($"Ошибка формата: {ex.Message}");
            }
        }

        /// <summary>Assumes the type of object.</summary>
        /// <param name="codeObject">The code object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">codeObject - The 'codeObject' parameter cannot be null or empty.</exception>
        static public TypeMeterData AssumeTypeOfObject(string codeObject) {
            if (string.IsNullOrEmpty(codeObject)) {
                throw new ArgumentNullException(nameof(codeObject), "The 'codeObject' parameter cannot be null or empty.");
            }

            if (codeObject.Split(';').Length - 1 == 6) {
                return TypeMeterData.MeterDataElectricity;
            }
            else if (codeObject.Split(';').Length - 1 == 5) {
                return TypeMeterData.MeterDataWater;
            }
            return TypeMeterData.InvalidType;
        }

        /// <summary>Determines the type of object format string.</summary>
        /// <param name="codeObject">The code object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">codeObject - Строка не должна быть null или пустой.
        /// or
        /// Ошибка: {ex.Message}</exception>
        /// <exception cref="System.FormatException">Ошибка формата: {ex.Message}</exception>
        static public string DetermineTypeOfObjectFormatString(string codeObject) {
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
        }

        /// <summary>Defines the quotation mark indexes.</summary>
        /// <param name="codeObject">The code object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.FormatException">Не найдена первая кавычка в строке.
        /// or
        /// Не найдена вторая кавычка в строке.</exception>
        static private (int indexFirstForging, int indexLastForging) DefineQuotationMarkIndexes(string codeObject) {
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