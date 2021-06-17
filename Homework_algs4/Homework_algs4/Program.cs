using BenchmarkDotNet.Running;
using System;

namespace Homework_algs4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Benchmark part for BTreePrinter class.
             */
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            var binaryTree = new BinaryTree();
            var rand = new Random();

            /*
             * This console-draw shit is very demanding to real height. 
             * So we will not risk and draw real GIANT trees.
             */
            for(int i = 1; i < 40; i++)
            {
                binaryTree.Add(rand.Next(i, 200));
            }

            //Node for test searching
            binaryTree.Add(11);

            Console.WriteLine("Это дерево");
            binaryTree.PrintTreeAsTree();

            BinaryTreeNode findNode = binaryTree.FindNode(11);
            string print = (findNode != null) 
                ? "Нода " + findNode.Data.ToString() + " найдена" 
                : "Нода не найдена";

            Console.WriteLine(print);
            Console.ReadLine();
        }
    }
}
