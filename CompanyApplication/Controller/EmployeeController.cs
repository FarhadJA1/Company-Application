using Domain.Models;
using Service.Services;
using Service.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class EmployeeController
    {
        Employee employee = new Employee();
        Company company = new Company();

        private EmployeeService employeeService;
        public EmployeeController()
        {
            employeeService = new EmployeeService();
        }

        public void Create()
        {
            try
            {
                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Company ID: \n");
            EnterID: string id = Console.ReadLine();
                int companyID;
                bool isTrueID = int.TryParse(id, out companyID);

                if (isTrueID)
                {
                    Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee Name: \n");
                    string employeeName = Console.ReadLine();

                    Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee Surname: \n");
                    string employeeSurname = Console.ReadLine();

                    Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee Age: \n");
                    string age = Console.ReadLine();


                    employee.Name = employeeName;
                    employee.Surname = employeeSurname;
                    employee.Age = age;

                    company.ID = companyID;

                    var createResult = employeeService.Create(employee, companyID);
                    if (createResult != null)
                    {
                        Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{employee.ID}. Employee Name: {employee.Name} , Employee Surname: {employee.Surname}, Company ID: {company.ID} - was Successfully Created !\n");
                    }
                    else
                    {
                        Helpers.WriteToConsole(ConsoleColor.Red, "Company not found!\n");
                    }

                }
                else
                {
                    Helpers.WriteToConsole(ConsoleColor.Red, "Something Went Wrong !\n");
                    goto EnterID;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void Delete()
        {
            try
            {

                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee Name:");
            EnterName: string name = Console.ReadLine();
                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee Surname:");
                string surname = Console.ReadLine();

                employee.Name = name;
                employee.Surname = surname;

                var deleteResult = employeeService.Delete(employee);


                if (deleteResult)
                {

                    Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"Name: {employee.Name}, Surname: {employee.Surname} - was Successfully Deleted !\n");
                }
                else
                {
                    Helpers.WriteToConsole(ConsoleColor.Red, "Employee not found! \n");
                    goto EnterName;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void GetByID()
        {
            try
            {
                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee ID:\n");

            EnterID: string emoloyeeID = Console.ReadLine();
                int id;
                bool isIdTrue = int.TryParse(emoloyeeID, out id);


                if (isIdTrue)
                {
                    var getIdResult = employeeService.GetEmployeeByID(id);
                    if (getIdResult == null)
                    {
                        Helpers.WriteToConsole(ConsoleColor.Red, "Employee is not Found !\n");
                        goto EnterID;
                    }
                    else
                    {
                        Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{getIdResult.ID}. Name: {getIdResult.Name}, Surname: {getIdResult.Surname} - was Successfully Found !\n");
                    }

                }
                else
                {
                    Helpers.WriteToConsole(ConsoleColor.Red, "Try Again !\n");
                    goto EnterID;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetByAge()
        {
            try
            {
                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee Age:\n");
            EnterAge: string age = Console.ReadLine();
                string empAge = employee.Age;

                var employeeAges = employeeService.GetEmployesByAge(empAge);

                if (employeeAges == null)
                {
                    Helpers.WriteToConsole(ConsoleColor.Red, "Employee was not Found !\n");
                    goto EnterAge;
                }
                else
                {
                    foreach (var item in employeeAges)
                    {
                        Helpers.WriteToConsole(ConsoleColor.Green, $"{item.ID}. Name: {item.Name}, Surname: {item.Surname}\n");
                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }

        public void Update()
        {
            try
            {
                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee ID:\n");

                EnterID: string companyID = Console.ReadLine();
                int id;
                bool isIdTrue = int.TryParse(companyID, out id);

                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add new Employee Name:\n");
                string newName = Console.ReadLine();
                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add new Employee Surname:\n");
                string newSurname = Console.ReadLine();
                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add new Employee Age:\n");
                string newAge = Console.ReadLine();

                if (isIdTrue)
                {
                    employee.Name = newName;
                    employee.Surname = newSurname;
                    employee.Age = newAge;


                    Employee newEmployee = employeeService.Update(id, employee);

                    Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{newEmployee.Name} - {newEmployee.Surname} - {newEmployee.Age} - was Successfully Updated!\n");


                }
                else
                {
                    Helpers.WriteToConsole(ConsoleColor.Red, "Try Again !\n");
                    goto EnterID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            
        }

        public void GetAllEmployesCompanyID()
        {
            try
            {
                Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee's Company ID:\n");
                EnterID: string id = Console.ReadLine();
                int comID;
                bool isTrueID = int.TryParse(id, out comID);

                if (isTrueID)
                {
                    var employeeCompany = employeeService.GetAllEmployesCompanyID(comID);

                    if (employeeCompany == null)
                    {
                        Helpers.WriteToConsole(ConsoleColor.Red, "Company is not Found !\n");
                        goto EnterID;
                    }
                    else
                    {
                        foreach (var item in employeeCompany)
                        {
                            Helpers.WriteToConsole(ConsoleColor.Green, $"{item.ID}. Name: {item.Name}, Surname: {item.Surname}\n");
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
