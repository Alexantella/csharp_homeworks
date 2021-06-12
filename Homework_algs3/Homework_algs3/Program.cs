using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Homework_algs3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class BenchmarkMethods
    {
        [Benchmark]
        public void DistanceWithPointClassFloatTest()
        {
            PointClassFloat pointOne = new PointClassFloat() { x = 1, y = 4 };
            PointClassFloat pointTwo = new PointClassFloat() { x = 6, y = 15 };

            DistanceWithPointClassFloat(pointOne, pointTwo);
        }

        [Benchmark]
        public void DistanceWithPointStructDoubleTest()
        {
            PointStructDouble pointOne = new PointStructDouble() { x = 1, y = 4 };
            PointStructDouble pointTwo = new PointStructDouble() { x = 6, y = 15 };

            DistanceWithPointStructDouble(pointOne, pointTwo);
        }

        [Benchmark]
        public void DistanceWithPointStructFloatTest()
        {
            PointStructFloat pointOne = new PointStructFloat() { x = 1, y = 4 };
            PointStructFloat pointTwo = new PointStructFloat() { x = 6, y = 15 };

            DistanceWithPointStructFloat(pointOne, pointTwo);
        }

        [Benchmark]
        public void DistanceWithPointStructFloatWithoutSqrtTest()
        {
            PointStructFloat pointOne = new PointStructFloat() { x = 1, y = 4 };
            PointStructFloat pointTwo = new PointStructFloat() { x = 6, y = 15 };

            DistanceWithPointStructFloatWithoutSqrt(pointOne, pointTwo);
        }

        public static float DistanceWithPointClassFloat(PointClassFloat pointOne, PointClassFloat pointTwo)
        {
            float x = pointOne.x - pointTwo.x;
            float y = pointOne.y - pointTwo.y;

            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double DistanceWithPointStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.x - pointTwo.x;
            double y = pointOne.y - pointTwo.y;

            return Math.Sqrt((x * x) + (y * y));
        }

        public static float DistanceWithPointStructFloat(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.x - pointTwo.x;
            float y = pointOne.y - pointTwo.y;

            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float DistanceWithPointStructFloatWithoutSqrt(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.x - pointTwo.x;
            float y = pointOne.y - pointTwo.y;

            return (x * x) + (y * y);
        }
    }

    public class PointClassFloat
    {
        public float x;
        public float y;
    }

    public class PointStructDouble
    {
        public double x;
        public double y;
    }

    public class PointStructFloat
    {
        public float x;
        public float y;
    }
}
