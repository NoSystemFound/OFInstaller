using System;
using System.IO;

namespace OFInstaller
{
    public class funcs
    {
        public string getPath()
        {
            string usr = Environment.GetEnvironmentVariable("username");
            string logPath = "C:\\Users\\" + usr + "\\Desktop\\log.txt";
            return logPath;
        }
        //
        public void logPrepare()
        {
            if (File.Exists(getPath()))
            {

            }
            else
            {
                File.Create(getPath()).Close();
            }
        }
        public void logWrite(string text)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string usr = Environment.GetEnvironmentVariable("username");
                string logtext = "[" + dt + "]: " + text;
                using(var sw = new StreamWriter(getPath(), true)) {
                    sw.WriteLine(logtext);
                    sw.Close();
                }
            }
            catch
            {

            }
        }
    }
}
