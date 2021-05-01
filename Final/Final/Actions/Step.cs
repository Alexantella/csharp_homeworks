using Final.Exceptions;
using Final.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Final.Actions
{
    class Step : Action
    {
        public string current { get; private set; }
        public void Create(params string[] args)
        {
            try
            {
                FileAttributes attributes = File.GetAttributes(args[1]);

                if ((attributes & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    throw new NotADirectoryException("You cannot move if path is not a directory");
                }

                this.current = args[1];
                this.WriteCurrent();
                this.Run();
            }
            catch (IndexOutOfRangeException)
            {
                throw new NotEnoughParamsException("You have to enter all nessesary params. Use /help for details");
            }
            catch (Exception e)
            {
                Logger.Logger.ErrorLog(e);
            }
        }

        private void Run()
        {
            Show show = new Show();
            string[] args = { "", this.current, "1" };
            show.Create(args);
        }

        private void WriteCurrent()
        {
            using (StreamWriter sw = new StreamWriter(CurrentDirectory.getStorage(), false, System.Text.Encoding.Default))
            {
                sw.WriteLine("{0}", this.current);
            }
        }
    }
}
