using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimiTools.Helper
{
    public class LoggerHelper
    {
        static string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        public static void Error(string message)
        {
            File.AppendAllText(logFile, DateTime.Now + "\t" + "Error\t" + message);
        }

        public static void Error(Exception ex)
        {
            File.AppendAllText(logFile, DateTime.Now + "\t" + "Error\t" + ex.Message + Environment.NewLine + ex.StackTrace);
        }


        public static void Info(string message)
        {
            File.AppendAllText(logFile, DateTime.Now + "\t" + "Info\t" + message);
        }
    }
}
