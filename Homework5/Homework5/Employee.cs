using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    class Employee
    {
        public string name;

        public string position;

        public string email;

        public long phone;

        public double salary;

        public int age;

        public Employee(
            string name, 
            string position, 
            string email, 
            long phone, 
            double salary, 
            int age
            )
        {
            this.name = name;
            this.position = position;
            this.email = email;
            this.phone = phone;
            this.salary = salary;
            this.age = age;
        }
    }
}
