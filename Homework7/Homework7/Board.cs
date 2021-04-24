using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7
{
    class Board
    {
        public static int SIZE_X = 5;
        public static int SIZE_Y = 5;
        int WIN_CNT = 4;

        public bool closeWinner = false;

        char[,] field = new char[SIZE_Y, SIZE_X];
        List<string> emptyDots = new List<string>();

        public Board()
        {
            this.InitField();
        }

        public void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
            emptyDots.Remove($"{y} {x}");
        }

        public List<string> getEmptyDots()
        {
            return emptyDots;
        }

        public bool IsFieldFull()
        {
            return emptyDots.Count == 0;
        }

        public void PrintField()
        {
            //Console.Clear();
            Console.WriteLine("-------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        public bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == (char) Char.EMPTY_DOT;
        }

        public bool CheckWin(char symb, int x, int y)
        {
            // Player score
            int vertical = 1;
            int horizontal = 1;
            int diagonal = 1;

            // Flag for reverse circle
            bool reverseCicle = false;

            // We need two iteration - to plus size and to minus size from symbol
            for (int j = 0; j < 2; j++)
            {
                int prevVer = 1;
                int prevHor = 1;
                int prevDiag = 1;
                reverseCicle = (j == 0) ? false : true;

                //Start to try value from 1 to our field size
                for (int i = 1; i < SIZE_X; i++)
                {
                    int newX;
                    int newY;

                    if (!reverseCicle)
                    {
                        newX = x + i;
                        newY = y + i;
                    }
                    else
                    {
                        newX = x - i;
                        newY = y - i;
                    }
                    
                    // We start to check positions on horizontal, vertical and diagonal
                    if (prevDiag != 0 && newY >= 0 && newY < SIZE_Y && newX >= 0 && newX < SIZE_X)
                    {
                        diagonal += (field[newY, newX] == symb) ? 1 : 0;
                        prevDiag = (field[newY, newX] == symb) ? 1 : 0;
                    }

                    if (prevVer != 0 && newY >= 0 && newY < SIZE_Y)
                    {
                        vertical += (field[newY, x] == symb) ? 1 : 0;
                        prevVer = (field[newY, x] == symb) ? 1 : 0;
                    }

                    if (prevHor != 0 && newX >= 0 && newX < SIZE_X)
                    {
                        horizontal += (field[y, newX] == symb) ? 1 : 0;
                        prevHor = (field[y, newX] == symb) ? 1 : 0;
                    }
                }
            }

            // If player has 2 symbols - AI start protection
            if (horizontal == WIN_CNT - 2 || vertical == WIN_CNT - 2 || diagonal == WIN_CNT - 2)
            {
                if(symb == (char) Char.PLAYER_DOT)
                         closeWinner = true;
            }

            return (horizontal == WIN_CNT || vertical == WIN_CNT || diagonal == WIN_CNT);
        }

        /// <summary>
        /// Method for AI to check player positions.
        /// Need to rewrite it, cause too many double code.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>true - if we have point for blocking player</returns>
        public bool FindWin(int x, int y)
        {
            char symb = (char)Char.PLAYER_DOT;
            int vertical = 1;
            int horizontal = 1;
            int diagonal = 1;

            bool reverseCicle = false;

            for (int j = 0; j < 2; j++)
            {
                int prevVer = 1;
                int prevHor = 1;
                int prevDiag = 1;
                reverseCicle = j == 0 ? false : true;

                for (int i = 1; i < SIZE_X; i++)
                {
                    int newX;
                    int newY;

                    if (!reverseCicle)
                    {
                        newX = x + i;
                        newY = y + i;
                    }
                    else
                    {
                        newX = x - i;
                        newY = y - i;
                    }
                    
                    if (prevDiag != 0 && newY >= 0 && newY < SIZE_Y && newX >= 0 && newX < SIZE_X)
                    {
                        diagonal += (field[newY, newX] == symb) ? 1 : 0;
                        prevDiag = (field[newY, newX] == symb) ? 1 : 0;
                    }

                    if (prevVer != 0 && newY >= 0 && newY < SIZE_Y)
                    {
                        vertical += (field[newY, x] == symb) ? 1 : 0;
                        prevVer = (field[newY, x] == symb) ? 1 : 0;
                    }

                    if (prevHor != 0 && newX >= 0 && newX < SIZE_X)
                    {
                        horizontal += (field[y, newX] == symb) ? 1 : 0;
                        prevHor = (field[y, newX] == symb) ? 1 : 0;
                    }
                }
            }
            if (horizontal > WIN_CNT - 2 || vertical > WIN_CNT - 2 || diagonal > WIN_CNT - 2)
            {
                SetSym(y, x, (char)Char.AI_DOT);
                return true;
            }

            return false;
        }

        private void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = (char)Char.EMPTY_DOT;
                    emptyDots.Add($"{i} {j}");
                }
            }
        }
    }
}
