using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_algs4
{
    public class BenchmarkTest
    {
        private readonly HashSet<int> myHash = new HashSet<int>();
        private readonly int[] myArray = new int[10000];
        public BenchmarkTest()
        {
            for (int i = 0; i< 10000; i++)
            {
                this.myHash.Add(i);
                this.myArray[i] = i;
            }
        }

        [Benchmark]
        public void FindInHashSet()
        {
            this.myHash.Contains(3567);
        }

        [Benchmark]
        public void FindInArray()
        {
            Array.IndexOf(this.myArray, 3567);
        }
    }
}
