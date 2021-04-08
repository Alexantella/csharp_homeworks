using System;
using System.Collections.Generic;
using System.Text;

namespace Homework4
{
    class MethodUser
    {
        private enum Seasons {
            Winter,
            Spring,
            Summer,
            Autumn,
        }
        public void NameCreator()
        {
            string[][] names = { 
                new string[]{ "Пушкин", "Александр", "Сергеевич"} ,
                new string[]{ "Пупкин", "Василий", "Петрович"} ,
                new string[]{ "Григорьев", "Константин", "Павлович"}, 
                new string[]{ "Самойлова", "Екатерина", "Карповна"} 
            };

            foreach (string[] value in names )
            {
                this.NameMethod(value[1], value[0], value[2]);
            }
        }
        public void NumbersWithSplitMethod()
        {
            bool countable = true;

            Console.WriteLine("Введите числа, разделенные пробелом");
            string numbersStr = Console.ReadLine();
            string[] numbers = numbersStr.Split(' ');
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    int number = int.Parse(numbers[i]);
                    sum += number;
                }
                catch
                {
                    continue;
                }
            }

            Console.WriteLine("Сумма введенных чисел: {0}", sum);

        }

        public void SeasonCaller()
        {
            Console.WriteLine("Введите номер месяца");
            int month = 0;
            month = int.Parse(Console.ReadLine());

            while (month > 12 || month < 0)
            {
                Console.WriteLine("Число должно находится в диапазоне между 1 и 12. Еще раз?");
                month = int.Parse(Console.ReadLine());
            }

            Seasons season = this.SeasonsMethod(month);
            this.SeasonWriter(season);
        }
        public void FibbonachiMethod()
        {
            Console.WriteLine("Введите количество чисел в последовательности");
            int finishNumber = 0;

            try
            {
                finishNumber = int.Parse(Console.ReadLine());
            } catch
            {
                finishNumber = -1;
            }

            while (finishNumber < 0 )
            {
                Console.WriteLine("Число должно быть положительным и быть числом. Еще раз?");
                finishNumber = int.Parse(Console.ReadLine());
            }

            this.FibbonachiCounter(0, 1, 1, finishNumber);
        }

        public void FibbonachiCounter(int current, int next, int now, int finish)
        {
            Console.WriteLine("{0}", current);
            int newNumber = current + next;

            if(now < finish)
            {
                this.FibbonachiCounter(next, newNumber, now + 1, finish);
            }
        }

        public void StringMethod()
        {
            string str1 = "Предложение один Теперь предложение два Предложение три";
            int start = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                if (Char.IsUpper(str1[i]))
                {
                    if (i > 0) {
                        Console.Write("{0}. ", str1.Substring(start, i - start).Trim());
                        start = i;
                    }
                }

                if(i == str1.Length - 1)
                {
                    Console.Write("{0}. ", str1.Substring(start, str1.Length -  start).Trim());
                }                   
            }
        }

        private Seasons SeasonsMethod(int month)
        {
            if (month < 3 || month == 12) return Seasons.Winter;
            else if (month > 2 && month < 6) return Seasons.Spring;
            else if (month > 5 && month < 9) return Seasons.Summer;
            else if (month > 8 && month < 11) return Seasons.Autumn;

            return Seasons.Winter;
        }

        private void SeasonWriter(Seasons season)
        {
            if (season == Seasons.Winter) Console.WriteLine("Зима");
            else if (season == Seasons.Spring) Console.WriteLine("Весна");
            else if (season == Seasons.Summer) Console.WriteLine("Лето");
            else if (season == Seasons.Autumn) Console.WriteLine("Осень");
        }

        private void NameMethod(string name, string surname, string patronimic)
        {
            Console.WriteLine("{0} {1} {2}", surname, name, patronimic);
        }
    }
}
