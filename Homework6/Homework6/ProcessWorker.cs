using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Homework6
{
    class ProcessWorker
    {
        public void GetProcessList()
        {
            Process[] procList = Process.GetProcesses();

            foreach(Process process in procList)
            {
                Console.WriteLine("{0} {1}", process.Id, process.ProcessName);
            }
        }

        public void KillProcess(string value)
        {
            try
            {
                int id = int.Parse(value);
                Console.WriteLine(id);

                if (!this.KillProcessById(id))
                {
                    this.KillProcessByName(value);
                } 
            }
            catch
            {
                this.KillProcessByName(value);
            }
        }

        private bool KillProcessById(int value)
        {
            Process process = Process.GetProcessById(value);
            bool exist = true;

            if (!process.HasExited)
            {
                process.Kill();

                while (exist)
                {
                    if(process.HasExited)
                    {
                        exist = false;
                        Console.WriteLine("Процесс с id {0} завершен", process.Id);
                    }
                }

                return true;
            }

            return false;
        }

        private bool KillProcessByName(string value)
        {
            Process[] processes = Process.GetProcessesByName(value);
            bool exist = true;

            foreach (Process process in processes)
            {
                process.Kill();
                exist = true;

                while (exist)
                {
                    if (process.HasExited)
                    {
                        exist = false;
                        Console.WriteLine("Процесс {0} завершен", value);
                    }
                }
            }

            return true;
        }
    }
}
