/* Method Injection Live Demo
* 
* Diana Guerrero
* Professor Aydin
* BCS 426 
* 5/2/21
* 
* Partner(s): Patrick Adams & Anthony Alvarez
* Resource(s): 
* 1. https://dotnettutorials.net/lesson/dependency-injection-design-pattern-csharp/
* 2. https://dotnettutorials.net/lesson/setter-dependency-injection-design-pattern-csharp/
*/

using System;
using System.Collections.Generic;

namespace DependencyInjectionExample
{
    // Employee.cs
    // Here we have the getters and setters for the Employee.cs file (combine for demo purposes)
    public class Employee
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Department
        {
            get;
            set;
        }
    }

    // EmployeeDAL.cs
    // Similar to what we've been doing in class we have the List
    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }

    // Here we are inheriting the Interface IEmployeeDAL
    public class EmployeeDAL : IEmployeeDAL
    {
        // Creating list of employees 
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> ListEmployees = new List<Employee>();
            // Get the Employees from the Database (for now we are hard coded the employees)
            ListEmployees.Add(new Employee() { ID = 1, Name = "Pranaya", Department = "IT" });
            ListEmployees.Add(new Employee() { ID = 2, Name = "Kumar", Department = "HR" });
            ListEmployees.Add(new Employee() { ID = 3, Name = "Rout", Department = "Payroll" });
            return ListEmployees;
        }
    }

    // EmployeeBL.cs
    public class EmployeeBL
    {
        public IEmployeeDAL employeeDAL;

        // Interface IEmployeeDAL being Injected
        public List<Employee> GetAllEmployees(IEmployeeDAL _employeeDAL)
        {
            employeeDAL = _employeeDAL;
            return employeeDAL.SelectAllEmployees();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create object of EmployeeBL class
            EmployeeBL employeeBL = new EmployeeBL();

            // Call to GetAllEmployees method with proper object.            
            List<Employee> ListEmployee = employeeBL.GetAllEmployees(new EmployeeDAL());

            foreach (Employee emp in ListEmployee)
            {
                Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.ID, emp.Name, emp.Department);
            }
            Console.ReadKey();
        }
    }
}