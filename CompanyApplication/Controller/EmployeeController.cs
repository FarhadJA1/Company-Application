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
                EnterAge: string age = Console.ReadLine();
                int num;
                bool isTrueNum = int.TryParse(age, out num);

                if (isTrueNum)
                {
                    
                    employee.Name = employeeName;
                    employee.Surname = employeeSurname;

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
                    goto EnterAge;
                }

            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Red, "Something Went Wrong !\n");
                goto EnterID;
            }
            
        }

        public void Delete()
        {
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee Name:");
            EnterName: string name = Console.ReadLine();
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Employee Surname:");
            string surname = Console.ReadLine();

            employee.Name = name;
            employee.Surname = surname;
            employeeService.Delete(employee);


            if (employee != null)
            {
                
                Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"Name: {employee.Name}, Surname: {employee.Surname} - was Successfully Deleted !\n");
            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Red, "Employee not found! \n");
                goto EnterName;
            }



        }
    }
}
