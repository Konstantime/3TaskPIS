using _2TaskPIS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _2TaskPIS {
    public class MeterDataReader {

        public string[] GetLinesCodesFromTextFile(string filePath) {
            string fileContent = GetTextFromFile(filePath);

            string[] result = fileContent.Split('\r');

            return result;
        }

        private string GetTextFromFile(string filePath) {
            try {
                using (StreamReader reader = new StreamReader(filePath)) {
                    return reader.ReadToEnd();
                }
            }
            catch (IOException ex) {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return null;
            }
        }
    }
}

