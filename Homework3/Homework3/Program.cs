using System;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalArray();
            Console.WriteLine("===========================");
            PhoneArray();
            Console.WriteLine("===========================");
            SymbolArray();
            Console.WriteLine("===========================");
            SeaBattleArray();
            Console.WriteLine("===========================");
            MovingArray();
            Console.ReadLine();
        }

        static void DiagonalArray()
        {
            int[,] array = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            int left = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine(array[i, j].ToString().PadLeft(left += 2));
                }
            }
        }

        static void PhoneArray()
        {
            string[,] phones = new string[5, 2] {
                { "Вася", "8 (800) 700-43-43"},
                { "Петя", "8 (926) 213-57-36"},
                { "Коля", "8 (800) 250-25-25"},
                { "Аня", "8 (495) 792-82-85"},
                { "Катя", "8 (926) 554-55-05"},
            };

            for (int i = 0; i < phones.GetLength(0); i++)
            {
                Console.WriteLine("Имя: {0}. Телефон: {1}", phones[i, 0], phones[i, 1]);
            }
        }

        static void SymbolArray()
        {
            Console.WriteLine("Введи строку");
            string userData = Console.ReadLine();
            char[] array = userData.ToCharArray();
            Array.Reverse(array);

            Console.WriteLine(new string(array));
        }

        static void SeaBattleArray()
        {
            // Field
            string[,] battle = new string[10, 10];

            // Size of ships. Key - ship-type, value - ship-count
            int[] ships = { 4, 3, 2, 1 };

            // Techical variables
            var rand = new Random();
            bool clearV = true;
            bool clearH = true;

            // "Arrayable" field size for counting
            int battleSize = battle.GetLength(0) - 1;

            // Let's our field!
            for (int i = 0; i < battle.GetLength(0); i++)
            {
                for (int j = 0; j < battle.GetLength(1); j++)
                {
                    battle[i, j] = "O";
                }
            }

            // And now - build our ships!
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < ships[i]; j++) {
                    // It SHOULD be rewrite with normal do-while and recursion. But not today.
                    Start:
                        // Set ours random coords
                        int row = rand.Next(1, 9);
                        int column = rand.Next(1, 9);
                        
                        //Set our tail-coords. They will mark the finil poin of our ship
                        int columnT = column;
                        int rowT = row;
                        
                        //Set array for small magic with random and... the magic?
                        int[][] coordz = new int[2][];
                        int magicInt = rand.Next(2);

                        // At first we need to check if we can set our ship vertically
                        for (int shipSize = 0; shipSize < (i + 1); shipSize++)
                        {
                            columnT = column + shipSize;

                            clearV = positionChecker(row, columnT, rowT, columnT, columnT, battleSize, battle);

                            if (!clearV)
                            {
                                columnT = column;
                                break;
                            }
                        }

                        // All the same for horizontal
                        for (int shipSize = 0; shipSize < (i + 1); shipSize++)
                        {
                            rowT = row + shipSize;

                            clearH = positionChecker(rowT, column, rowT, columnT, rowT, battleSize, battle);

                            if (!clearH)
                            {
                                rowT = row;
                                break;
                            }
                        }

                        //Set our array-magic.
                        if (clearV) coordz[0] = new int[2] { column, columnT };
                        if (clearH) coordz[1] = new int[2] { row, rowT };

                        /* 
                         * We need this part for a little random.
                         * Because if we will use only one dimention at first 
                         * and the second only if the first doesn't fit -
                         * we will risk to have the fild with only one direction of ships
                         * - horizontal or vertical.
                         * It is not how this sea battle works, isn't it?
                         */
                        if (magicInt == 0)
                        {
                                column = clearV ? coordz[0][0] : column;
                                row = (clearH && !clearV) ? coordz[1][0] : row;
                                columnT = clearV ? coordz[0][1] : column;
                                rowT = (clearH && !clearV) ? coordz[1][1] : row;
                        } 

                        if(magicInt == 1)
                        {
                                row = clearH ? coordz[1][0] : row;
                                rowT = clearH ? coordz[1][1] : row;
                                column = (!clearH && clearV) ? coordz[0][0] : column;
                                columnT = (!clearH && clearV) ? coordz[0][1] : column;
                        }

                        if (rowT > battleSize || columnT > battleSize || !(clearH || clearV))
                        {
                            goto Start;
                        }

                        if (clearH || clearV)
                        {
                            for (int y = column; y <= columnT; y++)
                            {
                                for (int x = row; x <= rowT; x++)
                                {
                                    battle[y, x] = "*";
                                }
                            }
                        }
                        else
                        {
                            goto Start;
                        }
                }
            }

            for (int i = 0; i < battle.GetLength(0); i++)
            {
                for (int j = 0; j < battle.GetLength(1); j++)
                {
                    if(battle[i, j] == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }

                    Console.Write($"  {battle[i, j]}  ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static bool positionChecker(
            int x, 
            int y, 
            int xTail, 
            int yTail, 
            int tail, 
            int borders,
            string[,] field
            )
        {
            if (tail > borders)
            {
                return false;
            }

            int[] neibours = SetNeibours(xTail, yTail, borders);

            if (
                    field[y, x] == "O" &&
                    field[neibours[0], x] == "O" &&
                    field[neibours[1], x] == "O" &&
                    field[y, neibours[2]] == "O" &&
                    field[y, neibours[3]] == "O"
                    )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int[] SetNeibours(int x, int y, int border)
        {
            int[] array = new int[4];

            array[0] = y - 1 > 0 ? y - 1 : y;
            array[1] = y + 1 < border ? y + 1 : y;
            array[2] = x - 1 > 0 ? x - 1 : x;
            array[3] = x + 1 < border ? x + 1 : x;

            return array;
        }

        static void MovingArray()
        {
            string[] array = { "яблоко", "груша", "лимон", "апельсин" };
            int length = array.Length;
            Console.WriteLine(string.Join("\n", array));
            Console.WriteLine("Введи размер смещения. Значение не должно быть больше {0}", length);
            int moveNumber = int.Parse(Console.ReadLine());
            int realLength = length - 1;

            while (Math.Abs(moveNumber) > length)
            {
                Console.WriteLine("Значение больше длины массива. Попробуй еще раз: ");
                moveNumber = int.Parse(Console.ReadLine());
            }

            if (moveNumber > 0)
            {
                for(int i = 0; i < moveNumber; i++)
                {
                    var tmp = array[realLength];

                    for (int j = realLength; j > 0; j--) array[j] = array[j - 1];

                    array[0] = tmp;
                }
            } else
            {
                for (int i = 0; i < Math.Abs(moveNumber); i++)
                {
                    var tmp = array[0];

                    for (int j = 1; j < length; j++) array[j - 1] = array[j];

                    array[array.Length - 1] = tmp;
                }
            }

            Console.WriteLine(string.Join("\n", array));
        }
    }
}