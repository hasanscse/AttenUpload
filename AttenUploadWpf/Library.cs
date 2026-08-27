using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttenUploadWpf
{
    public static class Library
    {
        public static void WriteErrorLog(Exception ex)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                streamWriter.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch
            {
            }
        }

        public static void WriteErrorLog(string Message)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                streamWriter.WriteLine(DateTime.Now.ToString() + ": " + Message);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch
            {
            }
        }
    }
}
