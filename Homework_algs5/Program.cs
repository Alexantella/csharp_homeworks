using System;

namespace Homework_algs5
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstAlgorithm b = new FirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);

            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.name);

            Console.WriteLine("____________________________________");

            Console.WriteLine("Traverse Graph\n------");
            b.TraverseDf(root);

            Console.WriteLine("\nSearch in Graph\n------");
            Employee eDf = b.SearchDf(root, "Eva");
            Console.WriteLine(eDf == null ? "Employee not found" : eDf.name);
            eDf = b.SearchDf(root, "Brian");
            Console.WriteLine(eDf == null ? "Employee not found" : eDf.name);
            eDf = b.SearchDf(root, "Soni");
            Console.WriteLine(eDf == null ? "Employee not found" : eDf.name);
        }
    }
}
