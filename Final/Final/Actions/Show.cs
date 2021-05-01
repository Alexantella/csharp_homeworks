using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Final.Logger;
using Final.Helpers;
using Final.Exceptions;

namespace Final.Actions
{
    class Show : Action
    {
        private int pageSize = 20;

        private int page = 1;

        private string path;
        public void Create(params string[] args)
        {
            try
            {
                if (args[1] == ".")
                {
                    this.path = CurrentDirectory.getCurrentDirectory();
                }
                else
                {
                    this.path = args[1];
                }

                if (args.Length < 3)
                {
                    this.page = 1;
                }
                else
                {
                    this.page = int.Parse(args[2]);
                }
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
                List<string> files = Directory.GetFiles(this.path, "*").ToList();
                List<string> directories = Directory.GetDirectories(this.path, "*").ToList();

                directories.AddRange(files);

                int offset = (this.page - 1) * this.pageSize;

                for (int i = offset; i < offset + this.pageSize; i++)
                {
                    if(i > directories.Count - 1)
                    {
                        break;
                    }

                    Console.WriteLine(Path.GetFileName(directories[i]));
                }

            } catch(Exception e)
            {
                Logger.Logger.ErrorLog(e);
            }
        }
    }
}
