using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Homework2
{
    class ReadLiner
    {
        private int intMonth, realNum;

        private double avgTemp;

        [Flags]
        private enum WeekDays : uint
        {
            None = 0b_00000000,
            Monday = 0b_00000001,
            Tuesday = 0b_00000010,
            Wednesday = 0b_00000100,
            Thursday = 0b_00001000,
            Friday = 0b_00010000,
            Saturday = 0b_00100000,
            Sunday = 0b_01000000,
        }

        WeekDays enumDayOfWeek;

        public void Run()
        {
            this.PrintRandomCheck();

            if (this.avgTemp == 0)
            {
                this.AverageTemp();
            }

            if (this.intMonth == 0)
            {
                this.MonthNumber();
            }

            if (this.realNum == 0)
            {
                this.realNumber();
            }

            if (this.enumDayOfWeek == 0)
            {
                this.ByteMasks();
            }

            Console.ReadLine();
        }

        private void AverageTemp()
        {
            Console.WriteLine("Введи минимальную температуру!");
            string min = Console.ReadLine();

            Console.WriteLine("Введи максимальную температуру!");
            string max = Console.ReadLine();

            if (!this.IsIntValid(min) || !this.IsIntValid(min))
            {
                Console.WriteLine("Какое-то число вовсе не число, попробуй еще раз!");
                this.Run();
            }
            else
            {
                int intMin = Convert.ToInt32(min);
                int intMax = Convert.ToInt32(max);

                if (intMin > intMax || intMax < intMin)
                {
                    Console.WriteLine("Я для тебя какая-то шутка?");
                    this.Run();
                }

                this.avgTemp = (Convert.ToInt32(min) + Convert.ToInt32(max)) / 2;
                Console.WriteLine($"Средняя температура по больнице - {this.avgTemp}");
            }
        }

        private void MonthNumber()
        {
            Console.WriteLine("Введи номер месяца");
            string month = Console.ReadLine();

            if (!this.IsIntValid(month))
            {
                Console.WriteLine("Какое-то число вовсе не число, попробуй еще раз!");
                this.Run();
            }

            this.intMonth = Convert.ToInt32(month);

            if (this.intMonth < 1 || this.intMonth > 12)
            {
                Console.WriteLine("В человеческом году не так много месяцев, как в эльфийском. Попробуй еще раз!");
                this.intMonth = 0;

                this.Run();
            }

            DateTime newDate = new DateTime(DateTime.Now.Year, this.intMonth, 1);

            Console.WriteLine($"Название текущего месяца: {newDate:MMMM}");

            int[] winter = { 12, 1, 2 };

            if (Array.IndexOf(winter, this.intMonth) >= 0 && this.avgTemp > 0)
            {
                Console.WriteLine("Типичная Московская зима, чо!");
            }
        }

        private void realNumber()
        {
            Console.WriteLine("Введи число");
            string number = Console.ReadLine();

            if (!this.IsIntValid(number))
            {
                Console.WriteLine("Какое-то число вовсе не число, попробуй еще раз!");
                this.Run();
            }

            this.realNum = Convert.ToInt32(number);

            if (this.realNum % 2 > 0)
            {
                Console.WriteLine("Число очень нечетное!");
            }
            else
            {
                Console.WriteLine("Число четное!");
            }
        }

        private bool IsIntValid(string value)
        {
            return Int32.TryParse(value, out int number);
        }

        private void ByteMasks()
        {
            WeekDays firstOffice = WeekDays.Tuesday |
                WeekDays.Wednesday |
                WeekDays.Thursday |
                WeekDays.Friday;

            WeekDays secondOffice = WeekDays.Monday |
                WeekDays.Tuesday |
                WeekDays.Wednesday |
                WeekDays.Thursday |
                WeekDays.Friday |
                WeekDays.Saturday |
                WeekDays.Sunday;

            Console.WriteLine("Офис 1. Рабочие дни: {0}", firstOffice.ToString("G"));
            Console.WriteLine("Офис 2. Рабочие дни: {0}", secondOffice.ToString("G"));
            Console.WriteLine("Сыграем в одну игру. Введи любое число текущего месяца");

            string officeDate = Console.ReadLine();
            if (!this.IsIntValid(officeDate))
            {
                Console.WriteLine("Какое-то число вовсе не число, попробуй еще раз!");
                this.Run();
            }

            int intOfficeDate = Convert.ToInt32(officeDate);
            DateTime myDT = DateTime.Today;
            int nowMonth = myDT.Month;
            int nowYear = myDT.Year;

            Calendar myCal = CultureInfo.InvariantCulture.Calendar;
            int daysInMonth = myCal.GetDaysInMonth(nowYear, nowMonth);

            if (intOfficeDate < 1 && daysInMonth < intOfficeDate)
            {
                Console.WriteLine("Совсем дурашка? Попробуй еще раз!");
                this.Run();
            }

            /*
             * We change culture to English because we need to find our day of week in enum.
             * It's not very clean way, of course, but seriously. It's homework.
             */
            CultureInfo culture = new CultureInfo("en-US");
            CultureInfo.CurrentCulture = culture;

            DateTime userDate = new DateTime(nowYear, nowMonth, intOfficeDate);

            /*
             * Parse our string day of week to enum type.
             */
            this.enumDayOfWeek = (WeekDays)Enum.Parse(typeof(WeekDays), userDate.ToString("dddd"));

            string firstOfficeEnable = firstOffice.HasFlag(this.enumDayOfWeek) ? "работает" : "закрыт";
            string secondOfficeEnable = secondOffice.HasFlag(this.enumDayOfWeek) ? "работает" : "закрыт";

            Console.WriteLine("Первый офис {0}", firstOfficeEnable);
            Console.WriteLine("Второй офис {0}", secondOfficeEnable);
        }

        private void PrintRandomCheck()
        {
            string name = "ЗАО \"Ромашка\"";
            string adress = "г.Москва, Цветной Бульвар, дом 25";

            Dictionary<string, double> goods = new Dictionary<string, double>();
            goods.Add("Молоко", 45.60);
            goods.Add("Хлеб", 11.23);
            goods.Add("Морковь", 100.3);
            goods.Add("Халат", 305.60);

            Console.WriteLine(name);
            Console.WriteLine(adress);

            double sum = 0.0;
            int sale = 18;

            foreach(KeyValuePair<string, double> keyValue in goods)
            {
                Console.WriteLine("{0} - {1}", keyValue.Key, keyValue.Value);
                sum += keyValue.Value;
            }

            double final = sum * (1 - ((double) sale / 100));

            Console.WriteLine("Сумма: {0}", sum);
            Console.WriteLine("Скидка: {0} %", sale);
            Console.WriteLine("Итог: {0}", final);
        }
    }
}
