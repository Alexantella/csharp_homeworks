using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Final.Helpers
{
    class CurrentDirectory
    {
        private static string storage = @"c:\storage\current.txt";

        public static string getCurrentDirectory()
        {
            if(!Directory.Exists(@"c:\storage\"))
            {
                Directory.CreateDirectory(@"c:\storage\");
            }

            if (!File.Exists(storage))
            {
                File.WriteAllText(storage, @"c:\");
            }

            using (StreamReader sr = File.OpenText(storage))
            {
                return sr.ReadLine();
            }
        }

        public static string getStorage()
        {
            return storage;
        }

    }
}
