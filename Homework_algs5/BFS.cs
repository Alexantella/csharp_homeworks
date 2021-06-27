using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_algs5
{
    public class Employee
    {
        public Employee(string name)
            {
                this.name = name;
            }

        public string name { get; set; }
        public List<Employee> Employees
        {
            get
            {
                return EmployeesList;
            }
        }

        public void isEmployeeOf(Employee p)
        {
            EmployeesList.Add(p);
        }

        List<Employee> EmployeesList = new List<Employee>();

        public override string ToString()
        {
            return name;
        }
    }

    public class FirstAlgorithm
    {
        public Employee BuildEmployeeGraph()
        {
            Employee Eva = new Employee("Eva");
            Employee Sophia = new Employee("Sophia");
            Employee Brian = new Employee("Brian");
            Eva.isEmployeeOf(Sophia);
            Eva.isEmployeeOf(Brian);

            Employee Lisa = new Employee("Lisa");
            Employee Tina = new Employee("Tina");
            Employee John = new Employee("John");
            Employee Mike = new Employee("Mike");
            Sophia.isEmployeeOf(Lisa);
            Sophia.isEmployeeOf(John);
            Brian.isEmployeeOf(Tina);
            Brian.isEmployeeOf(Mike);

            return Eva;
        }

        public Employee Search(Employee root, string nameToSearchFor)
        {
            Queue<Employee> Q = new Queue<Employee>();
            HashSet<Employee> S = new HashSet<Employee>();
            Q.Enqueue(root);
            S.Add(root);

            while (Q.Count > 0)
            {
                Employee e = Q.Dequeue();
                if (e.name == nameToSearchFor)
                    return e;
                foreach (Employee friend in e.Employees)
                {
                    if (!S.Contains(friend))
                    {
                        Q.Enqueue(friend);
                        S.Add(friend);
                    }
                }
            }
            return null;
        }

        public void Traverse(Employee root)
        {
            Queue<Employee> traverseOrder = new Queue<Employee>();

            Queue<Employee> Q = new Queue<Employee>();
            HashSet<Employee> S = new HashSet<Employee>();
            Q.Enqueue(root);
            S.Add(root);

            while (Q.Count > 0)
            {
                Employee e = Q.Dequeue();
                traverseOrder.Enqueue(e);

                foreach (Employee emp in e.Employees)
                {
                    if (!S.Contains(emp))
                    {
                        Q.Enqueue(emp);
                        S.Add(emp);
                    }
                }
            }

            while (traverseOrder.Count > 0)
            {
                Employee e = traverseOrder.Dequeue();
                Console.WriteLine(e);
            }
        }

        public Employee SearchDf(Employee root, string nameToSearchFor)
        {
            if (nameToSearchFor == root.name)
                return root;

            Employee personFound = null;
            for (int i = 0; i < root.Employees.Count; i++)
            {
                personFound = SearchDf(root.Employees[i], nameToSearchFor);
                if (personFound != null)
                    break;
            }
            return personFound;
        }

        public void TraverseDf(Employee root)
        {
            Console.WriteLine(root.name);
            for (int i = 0; i < root.Employees.Count; i++)
            {
                TraverseDf(root.Employees[i]);
            }
        }
    }
}
