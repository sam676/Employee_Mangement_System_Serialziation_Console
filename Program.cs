using System;
using static EmployeeRepoConsoleSerialziation.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.IO;


// An employee management system that uses serialization and the console for display.


namespace EmployeeRepoConsoleSerialziation
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create new Employee Repo
            EmployeeRepoSerialization er = new EmployeeRepoSerialization(@"C:/EmployeeDirectory");

            //Create list of Employees
            er.CreateEmployee(new Employee { FirstName = "Blob", LastName = "Frank", EmployeeID = 100, Department = "Engineering" });
            er.CreateEmployee(new Employee { FirstName = "Bob", LastName = "Smith", EmployeeID = 101, Department = "Engineering" });
            er.CreateEmployee(new Employee { FirstName = "Rob", LastName = "Jones", EmployeeID = 102, Department = "Engineering" });


            //Return list of all Employees
            var employeeAll = er.GetAll();
            Console.WriteLine("\nReturn list of all Employees: ");
            foreach (Employee emp in employeeAll) {
                Console.WriteLine(emp);
            }


            //Delete Employee by ID
            Employee getEmp = er.GetEmployeeByID(101);
            Console.WriteLine($"\nDeleting Employee by ID: {getEmp}");
            er.DeleteEmployee(101);

            //Deleting Employee by Employee Type
            getEmp = er.GetEmployeeByID(102);
            Console.WriteLine($"\nDeleting Employee by Employee: {getEmp}");
            er.DeleteEmployee(getEmp);
            

            //Print List of Employees
            employeeAll = er.GetAll();
            Console.WriteLine("\nRemaining Employees:");
            foreach (Employee emp in employeeAll)
            {
                Console.WriteLine(emp);
            }

            //Get Employee by ID
            Console.WriteLine("\nGet Employee 100:");
            getEmp = er.GetEmployeeByID(100);
            Console.WriteLine(getEmp);

            //Update Employee
            Console.WriteLine($"\nOriginal employee data:  {getEmp}");
            er.UpdateEmployee(new Employee { FirstName = "Bob", LastName = "Smith", EmployeeID = 201, Department = "Engineering" });
            getEmp = er.GetEmployeeByID(201);
            Console.WriteLine($"Updated employee data: {getEmp}");



        }
    }
}
