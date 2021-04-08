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


            var allEmp = er.GetAll();
            Console.WriteLine("\nCurrent list of Employees:");
            foreach (Employee emp in allEmp)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("\n Pick from the following: ");
            Console.WriteLine("\n 1. Add Employee \n 2. Return all Employees \n 3. Get Employee by ID \n 4. Delete Employee by ID \n 5. Delete Employee using Employee data \n 6. Update Employee \n");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                //Add to list of Employees
                Console.WriteLine("Add a new Employee ");
                Console.WriteLine("First Name:");
                string FN = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                string LN = Console.ReadLine();
                Console.WriteLine("Employee ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Department: ");
                string dept = Console.ReadLine();
                er.CreateEmployee(new Employee { FirstName = FN, LastName = LN, EmployeeID = ID, Department = dept });

            }
            else if (choice == "2")
            {

                //Return list of all Employees
                var employeeAll = er.GetAll();
                Console.WriteLine("\nReturn list of all Employees: ");
                foreach (Employee emp in employeeAll)
                {
                    Console.WriteLine(emp);
                }

            }
            else if (choice == "3")
            {

                //Get Employee by ID
                Console.WriteLine("\nGet Employee #:");
                int EmpID = Convert.ToInt32(Console.ReadLine());
                Employee emp = er.GetEmployeeByID(EmpID);
                Console.WriteLine(emp);

            }
            else if (choice == "4")
            {

                //Delete Employee by ID
                Console.WriteLine($"\nDelete Employee by ID: ");
                int EmpID = Convert.ToInt32(Console.ReadLine());
                Employee getEmp = er.GetEmployeeByID(EmpID);
                er.DeleteEmployee(EmpID);

                //Print List of Employees
                var all = er.GetAll();
                Console.WriteLine("\nNew list of Employees:");
                foreach (Employee emp in all)
                {
                    Console.WriteLine(emp);
                }


            }
            else if (choice == "5")
            {
                //Deleting Employee by Employee Type
                Console.WriteLine($"Delete Employee:");
                Console.WriteLine("First Name:");
                string FN = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                string LN = Console.ReadLine();
                Console.WriteLine("Employee ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Department: ");
                string dept = Console.ReadLine();
                er.UpdateEmployee(new Employee { FirstName = FN, LastName = LN, EmployeeID = ID, Department = dept });
                Employee emp = er.GetEmployeeByID(ID);
                Console.WriteLine($"\nDeleting Employee by Employee: {emp}");
                er.DeleteEmployee(emp);

                //Print List of Employees
                var all = er.GetAll();
                Console.WriteLine("\nNew list of Employees:");
                foreach (Employee em in all)
                {
                    Console.WriteLine(em);
                }




            }
            else if (choice == "6")
            {
                //Update Employee
                Console.WriteLine($"Update Employee:");
                Console.WriteLine("First Name:");
                string FN = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                string LN = Console.ReadLine();
                Console.WriteLine("Employee ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Department: ");
                string dept = Console.ReadLine();
                er.UpdateEmployee(new Employee { FirstName = FN, LastName = LN, EmployeeID = ID, Department = dept });
                Employee getEmp = er.GetEmployeeByID(ID);
                Console.WriteLine($"Updated employee data: {getEmp}");


            }
            else {

                Console.WriteLine("Sorry invalid chocie!");

            }


          





        }
    }
}
