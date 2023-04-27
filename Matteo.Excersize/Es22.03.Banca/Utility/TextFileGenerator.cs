using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.Utility
{
    static class TextFileGenerator
    {
        public static void Savetofile<T>(List<T> data, string filePath)
        {

            StringBuilder line = new StringBuilder();
            var cols = data[0].GetType().GetProperties();

            if (!File.Exists(filePath)) appendText(cols, line, data, filePath);
            else
            {
                var rows = File.ReadAllLines(filePath).ToList();
                var header = rows[0].Split(",");

                if (header.Length != cols.Length || rows.Count != data.Count)
                {
                    File.WriteAllText(filePath, String.Empty);
                    appendText(cols, line, data, filePath);
                }
            }

            Console.WriteLine($"Creato il file {filePath}");
            Console.WriteLine($"-----------------------------------------------\n");
        }

        private static void appendText<T>(PropertyInfo[] cols, StringBuilder line, List<T> data, string filepath)
        {
            foreach (var col in cols)
            {
                if (col != cols.Last()) line.Append(string.Format($"{col.Name},"));
                else line.Append(string.Format($"{col.Name}"));

            }
            File.AppendAllText(filepath, line.ToString());
            foreach (var row in data)
            {
                line = new StringBuilder();
                line.AppendLine();

                foreach (var col in cols)
                {
                    string value = col.GetValue(row).ToString();
                    if (col != cols.Last()) line.Append(string.Format($"{value},"));
                    else line.Append(string.Format($"{value}"));
                }
                File.AppendAllText(filepath, line.ToString());
            }

        }


    }
}
