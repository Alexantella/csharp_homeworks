using System;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessManager();
            ArrayManager();
        }

        static void ArrayManager()
        {
            String[,] correct = {
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"}
            };
            String[,] incorrect = {
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"}
            };
            String[,] incorrect2 = {
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "sadasdadad"},
                {"1", "2", "3", "4"}
            };

            try
            {
                Console.WriteLine("Сумма = {0}", ArrayProcessor(correct));
                //Console.WriteLine("Сумма = {0}", ArrayProcessor(incorrect));
                Console.WriteLine("Сумма = {0}", ArrayProcessor(incorrect2));
            }
            catch (MyArraySizeExeption)
            {
                Console.WriteLine("Размер массива не верен");
            }
            catch (MyArrayDataExeption ex)
            {
                Console.WriteLine("Массив содержит данные, не являющиеся цифрами. {0}", ex.Message);
            }

        }

        static void ProcessManager()
        {
            bool holder = true;
            ProcessWorker processor = new ProcessWorker();

            processor.GetProcessList();

            while (holder)
            {
                Console.WriteLine("Введите id или название процесса, который желаете завершить");
                Console.WriteLine("Введите /processlist если желаете снова вывести список процессов");
                Console.WriteLine("Введите /stop если желаете выйти из приложения");

                string line = Console.ReadLine();

                if (line == "/processlist")
                {
                    processor.GetProcessList();
                }
                else if (line == "/stop")
                {
                    holder = false;
                }
                else
                {
                    processor.KillProcess(line);
                }
            }
        }

        static int ArrayProcessor(string[,] data)
        {
            if (data.GetUpperBound(0) != 3 || data.GetUpperBound(1) != 3)
                throw new MyArraySizeExeption();

            int sum = 0;
            int num;

            for(int i = 0; i < data.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < data.GetUpperBound(1) + 1; j++)
                {
                    bool isInt = int.TryParse(data[i, j], out num);
                    if (!isInt)
                    {
                        throw new MyArrayDataExeption(i,j);
                    }

                    sum += num;
                }
            }

            return sum;
        }
    }
}
