using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Final.Logger
{
    class Logger
    {
        private static string file = "exeptions.txt";

        private static string directory = @"c:\errors\";

        public static void ErrorLog (Exception ex)
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

                Console.WriteLine(ex.Message);

                using (StreamWriter sw = new StreamWriter(Path.Combine(directory, file), true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("{0}", ex.Message);
                    sw.WriteLine("{0}", ex.StackTrace);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
