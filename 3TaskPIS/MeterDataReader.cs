using TaskPis2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TaskPis2 {
    static public class MeterDataReader {

        static public string[] GetLinesCodesFromTextFile(string filePath) {
            string fileContent = GetTextFromFile(filePath);

            string[] result = fileContent.Split('\r');

            return result;
        }

        static private string GetTextFromFile(string filePath) {
            try {
                using (StreamReader reader = new StreamReader(filePath)) {
                    return reader.ReadToEnd();
                }
            }
            catch (IOException ex) {
                throw new IOException($"Error reading file: {ex.Message}", ex);
            }
        }
    }
}

