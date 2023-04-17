using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.Utility
{
    public class LogSystem
    {
        static public void writeLogs(string Log, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else File.AppendAllText(Path.Combine(path, fileName), Log);
        }
    }
}
