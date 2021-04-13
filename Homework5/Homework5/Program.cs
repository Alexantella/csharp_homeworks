using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWriter();
            FileDateWriter();
            BinFileWriter();

            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee("Горбунов Антон Николаевич", "менеджер","test1@test.test",89871094627,30000.3,25));
            employees.Add(new Employee("Кудрявцев Вольдемар Федосеевич", "программист","test2@test.test",89993546789,100000.54,27));
            employees.Add(new Employee("Самсонова Камилла Евгеньевна", "врач","test3@test.test",89098672365,100000,50));
            employees.Add(new Employee("Лыткина Наталья Валерьяновна", "таргетолог","test4@test.test",89038652756,60000.65,33));
            employees.Add(new Employee("Пахомова Агата Николаевна", "бухгалтер","test5@test.test",89886542737,80907.54,43));

            foreach(Employee employee in employees)
            {
                if(employee.age > 40)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(employee));
                }
            }

        }

        static void FileWriter()
        {
            string path = @"C:\Tests";
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            Console.WriteLine("Введите данные");
            string data = Console.ReadLine();

            try
            {
                using (StreamWriter sw = new StreamWriter($"{path}/work1.txt", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(data);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        static void FileDateWriter()
        {
            string path = @"C:\Tests";
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            try
            {
                using (StreamWriter sw = new StreamWriter($"{path}/startup.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(DateTime.Now);
                }
                Console.WriteLine("Запись выполнена. Дата {0}", DateTime.Now);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static void BinFileWriter()
        {
            string path = @"C:\Tests";
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            try
            {
                Console.WriteLine("Введите данные");
                string[] data = Console.ReadLine().Split(" ");
                int parse;

                using (BinaryWriter writer = new BinaryWriter(File.Open($"{path}/work3.dat", FileMode.Create)))
                {
                    foreach (string num in data)
                    {
                        if (int.TryParse(num, out parse)) 
                        {
                            if (parse > 0 && parse <= 255)
                            {
                                writer.Write(num);
                            }
                        }
                    }
                    Console.WriteLine("Запись выполнена");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
