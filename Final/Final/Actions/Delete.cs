using Final.Exceptions;
using Final.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Final.Actions
{
    class Delete : Action
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
                FileAttributes attributes = File.GetAttributes(Path.Combine(this.directory, this.file));

                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    Directory.Delete(Path.Combine(this.directory, this.file), true);
                } else
                {
                    File.Delete(Path.Combine(this.directory, this.file));
                }
                
            }
            catch (Exception e)
            {
                Logger.Logger.ErrorLog(e);
            }
        }
    }
}
