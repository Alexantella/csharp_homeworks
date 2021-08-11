using System;

namespace Homework_algs7
{
    class Program
    {
        static void Main(string[] args)
        {
			// Field size
			int x = 3;
			int y = 5;

			int[,] field = new int[x,y];

			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					if (i == 0 || j == 0)
					{
						field[i,j] = 1;
					}
					else
					{
						field[i,j] = field[i - 1,j] + field[i,j - 1];
					}
				}
			}

			Console.WriteLine(field[x - 1,y - 1]);
		}
    }
}
