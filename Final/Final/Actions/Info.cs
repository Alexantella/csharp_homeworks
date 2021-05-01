using Final.Exceptions;
using Final.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Final.Actions
{
    class Info : Action
    {
        private string directory;
        private string file;

        public void Create(params string[] args)
        {
            try
            {
                if (args[1] == ".")
                {
                    this.directory = CurrentDirectory.getCurrentDirectory();
                }
                else
                {
                    this.directory = args[1];
                }
                
                this.file = args[2];
                this.Run();
            }
            catch (IndexOutOfRangeException)
            {
                throw new NotEnoughParamsException("You have to enter all nessesary params. Use /help for details");
            }
        }

        private void Run()
        {
            try
            {
                FileInfo file = new FileInfo(Path.Combine(this.directory, this.file));
                Console.WriteLine("Создан: {0}", file.CreationTime);
                Console.WriteLine("Перезаписан: {0}", file.LastWriteTime);
                Console.WriteLine("Длина в битах: {0}", file.Length);
            }
            catch (Exception e)
            {
                Logger.Logger.ErrorLog(e);
            }
        }
    }
}
