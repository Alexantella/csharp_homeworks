using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Final.Logger
{
    class History
    {
        private static string file = "history.txt";

        private static string directory = @"c:\storage\";
        public static void HistoryLog(string commandLine)
        {
            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (!File.Exists(Path.Combine(directory, file)))
                {
                    File.WriteAllText(Path.Combine(directory, file), "");
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(directory, file), true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("{0}", commandLine);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<string> HistoryLoad()
        {
            using (StreamReader sr = File.OpenText(Path.Combine(directory, file)))
            {
                List<string> command = new List<string>();
                string cmd;

                while((cmd = sr.ReadLine()) != null) {
                    command.Add(cmd);
                }

                return command;
            }
        }
    }
}
