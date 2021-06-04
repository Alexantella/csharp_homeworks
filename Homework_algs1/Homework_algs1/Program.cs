using System;

namespace Homework_algs1
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleNumber(2);
            SimpleNumber(4);
            SimpleNumber(5);
            SimpleNumber(6);
            SimpleNumber(10);

            FibbonachiMethod();
        }

        public static void SimpleNumber(int number)
        {
            int d = 0;

            for(int i = 2; i < number; i++)
            {
                if(number%i == 0)
                {
                    d++;
                }
            }

            if(d == 0)
            {
                Console.WriteLine("Число {0} простое", number);
            } else
            {
                Console.WriteLine("Число {0} не простое", number);
            }
        }


        public static void FibbonachiMethod()
        {
            Console.WriteLine("Введите номер числа в последовательности");
            int finishNumber = 0;

            try
            {
                finishNumber = int.Parse(Console.ReadLine());
            }
            catch
            {
                finishNumber = -1;
            }

            while (finishNumber < 0)
            {
                Console.WriteLine("Число должно быть положительным и быть числом. Еще раз?");
                finishNumber = int.Parse(Console.ReadLine());
            }

            // O(n)
            FibbonachiCounter(0, 1, 1, finishNumber);
            Console.WriteLine();

            // O(n)
            NoRecursionFibbonachiCounter(finishNumber);
        }

        public static void FibbonachiCounter(int current, int next, int now, int finish)
        {
            Console.Write("{0}, ", current);
            int newNumber = current + next;

            if (now < finish)
            {
                FibbonachiCounter(next, newNumber, now + 1, finish);
            }
        }

        public static void NoRecursionFibbonachiCounter(int finish)
        {
            int current = 0;
            int prev = 0;
            int next = 1;

            for(int i = 0; i < finish; i++)
            {
                Console.Write("{0}, ", current);

                if (current > 0)
                {
                    int store = current;
                    current = prev + next;
                    prev = store;
                } 
                else
                {
                    current = i + 1;
                }

                next = current;
            }
        }
    }
}
