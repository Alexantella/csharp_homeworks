using Final.Exceptions;
using Final.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Final.Actions
{
    class Copy : Action
    {
        private string from;

        private string to;

        private string fileName;
        public void Create(params string[] args)
        {
            try
            {
                if (args[1] == ".")
                {
                    this.from = CurrentDirectory.getCurrentDirectory();
                }
                else
                {
                    this.from = args[1];
                }
                
                this.to = args[2];
                this.fileName = args[3];
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
                FileAttributes attributes = File.GetAttributes(Path.Combine(this.from, this.fileName));

                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    Directory.CreateDirectory(Path.Combine(this.to, this.fileName));
                    this.CopyDirectory(Path.Combine(this.from, this.fileName));
                }
                else
                {
                    File.Copy(Path.Combine(this.from, this.fileName), Path.Combine(this.to, this.fileName));
                }
            }
            catch (Exception e)
            {
                Logger.Logger.ErrorLog(e);
            }
        }

        private void CopyDirectory(string directoryPath)
        {
            List<string> fileList = Directory.GetFiles(directoryPath, "*").ToList();
            List<string> directoryList = Directory.GetDirectories(directoryPath, "*").ToList();

            fileList.AddRange(directoryList);

            if(fileList.Count == 0)
            {
                return;
            }

            foreach (string f in fileList)
            {
                FileAttributes attributes = File.GetAttributes(f);

                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    string DName = f.Substring(this.from.Length + 1);
                    Directory.CreateDirectory(Path.Combine(this.to, DName));
                    this.CopyDirectory(f);
                    continue;
                }

                string fName = f.Substring(this.from.Length + 1);
                File.Copy(f, Path.Combine(this.to, fName), true);
            }
        }
    }
}
