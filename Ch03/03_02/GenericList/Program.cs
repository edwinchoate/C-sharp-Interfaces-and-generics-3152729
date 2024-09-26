using System;
using System.Collections.Generic;

namespace GenericList
{
    class Employee
    {
        public string mName;
        public int mSalary;

        public Employee(string name, int salary) {
            mName = name;
            mSalary = salary;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            // TODO: Create a new empty List for Employee objects 
            List<Employee> employees = new List<Employee>(16); // you can set the list capacity (16) upon construction

            // TODO: Add some records to the list
            employees.Add(new Employee("Bill Smith", 50000));
            employees.Add(new Employee("Bob Dorsey", 60000));
            employees.Add(new Employee("Betty McCalister", 70000));

            // TODO: Inspect some List properties
            Console.WriteLine("Capacity: {0}", employees.Capacity);
            Console.WriteLine("Count: {0}", employees.Count);

            // TODO: Use Exists() and Find()
            Console.WriteLine("Bob .Exists? {0}", employees.Exists((e) => e.mName == "Bob Dorsey"));
            Console.WriteLine("Jack .Exists? {0}", employees.Exists((e) => e.mName == "Jack Dorsey"));

            Console.WriteLine("Does anyone make over 65k? {0}", employees.Exists(HighPay));

            Console.WriteLine("Who makes 70k? {0}", employees.Find((e) => e.mSalary == 70000).mName);

            Console.WriteLine("Whose name ends in 'y'? {0}", employees.Find((e) => e.mName[e.mName.Length - 1] == 'y').mName); 

            Console.WriteLine();

            // TODO: Use ForEach to iterate over each item
            foreach (Employee employee in employees) 
            {
                Console.WriteLine(employee.mName);
            }

            employees.ForEach(TotalSalaries);

            Console.WriteLine("Total payroll is: {0}", total.ToString());

            // Console.WriteLine("\nPress Enter key to continue...");
            // Console.ReadLine();
        }

        // Iterator function for the ForEach method
        static int total = 0;
        static void TotalSalaries(Employee e) {
           total += e.mSalary;
        }

        // delegate function to use for the Exists method
        static Boolean HighPay(Employee emp) {
           return emp.mSalary >= 65000;
        }
    }
}
