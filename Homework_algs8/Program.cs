using System;
using System.Collections.Generic;

namespace Homework_algs8
{
    class Program
    {
        static void Main(string[] args)
        {
			int[] data = new int[] { -3, 102, -698, 7, -89, 5, 376, 0 };
			BucketSort(ref data);
			Console.WriteLine(string.Join(",", data));
        }

		public static void BucketSort(ref int[] data)
		{
			int minValue = data[0];
			int maxValue = data[0];

			for (int i = 1; i < data.Length; i++)
			{
				if (data[i] > maxValue)
					maxValue = data[i];
				if (data[i] < minValue)
					minValue = data[i];
			}

			List<int>[] bucket = new List<int>[maxValue - minValue + 1];

			for (int i = 0; i < bucket.Length; i++)
			{
				bucket[i] = new List<int>();
			}

			for (int i = 0; i < data.Length; i++)
			{
				bucket[data[i] - minValue].Add(data[i]);
			}

			int k = 0;
			for (int i = 0; i < bucket.Length; i++)
			{
				if (bucket[i].Count > 0)
				{
					for (int j = 0; j < bucket[i].Count; j++)
					{
						data[k] = bucket[i][j];
						k++;
					}
				}
			}
		}
	}
}
