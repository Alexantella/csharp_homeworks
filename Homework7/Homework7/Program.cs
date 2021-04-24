using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7
{
    class Cross
    {
        static bool playerWin = false;
        static bool aiWin = false;

        static Random random = new Random();

        private static void playerMove(Board field)
        {
            int x = 0;
            int y = 0;

            bool isValid = false;
            bool isXValid = false;
            bool isYValid = false;

            do
            {
                while (!isYValid)
                {
                    Console.WriteLine("Координат по строке ");
                    Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до {0}", Board.SIZE_Y);
                    try
                    {
                        x = Int32.Parse(Console.ReadLine()) - 1;
                        isYValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Значение некорректно");
                    }
                }

                while (!isXValid)
                {
                    Console.WriteLine("Координат по столбцу");
                    Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до {0}", Board.SIZE_X);
                    try
                    {
                        y = Int32.Parse(Console.ReadLine()) - 1;
                        isXValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Значение некорректно");
                    }
                }

                isValid = field.IsCellValid(y, x);
                if (!isValid)
                {
                    Console.WriteLine("Значение некорректно. Попробуйте еще раз");
                }
            } while (!isValid);

            field.SetSym(y, x, (char)Char.PLAYER_DOT);

            if (field.CheckWin((char)Char.PLAYER_DOT, x, y))
            {
                playerWin = true;
            }
        }

        private static void AiMove(Board field)
        {
            int x = 0;
            int y = 0;

            if(field.closeWinner)
            {
                // If player has 2 spots ai start to check through board
                // and try to find a place to block player
                List<string> emptyDots = field.getEmptyDots();

                foreach(string dot in emptyDots)
                {
                    string[] coords = dot.Split(" ");
                    int i = Int32.Parse(coords[0]);
                    int j = Int32.Parse(coords[1]);
                    if (field.FindWin(j, i))
                    {
                        y = i;
                        x = j;
                        break;
                    }
                }
            } else {
                do
                {
                    x = random.Next(0, Board.SIZE_X);
                    y = random.Next(0, Board.SIZE_Y);
                } while (!field.IsCellValid(y, x));

                field.SetSym(y, x, (char)Char.AI_DOT);
            }

            if (field.CheckWin((char)Char.AI_DOT, x, y))
            {
                aiWin = true;
            }
        }

        static void Main(string[] args)
        {
            Board field = new Board();
            field.PrintField();

            do
            {
                playerMove(field);
                Console.WriteLine("Ваш ход на поле");
                field.PrintField();
                if (playerWin)
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (field.IsFieldFull()) break;
                AiMove(field);
                Console.WriteLine("Ход Компа на поле");
                field.PrintField();
                if (aiWin)
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (field.IsFieldFull()) break;
            } while (true);
            Console.WriteLine("!Конец игры!");
        }
    }
}
