using CompanyApplication.Controller;
using Domain.Models;
using Service.Helpers;
using Service.Interfaces;
using Service.Services;
using Service.Services.Helpers;
using System;

namespace CompanyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyController companyController = new CompanyController();
            
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "WELCOME!\n");
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Please, select option:\n");
            
            
            while (true)
            {

                ShowMenu();

                EnterOption: string selectOption = Console.ReadLine();
                int option;
                bool IsTrueOption = int.TryParse(selectOption, out option);

                if (IsTrueOption)
                {
                    switch (option)
                    {
                       case (int)MyEnum.Menu.CreateCompany:
                            companyController.Create();
                            break;

                        case (int)MyEnum.Menu.UpdateCompany:
                            break;

                        case (int)MyEnum.Menu.DeleteCompany:
                            companyController.Delete();
                            break;

                        case (int)MyEnum.Menu.GetCompanyByID:
                            companyController.GetByID();
                            break;

                        case (int)MyEnum.Menu.GetAllCompaniesByName:
                            companyController.GetAllByName();
                            break;

                        case (int)MyEnum.Menu.GetAllCompanies:
                            companyController.GetAllCompanies();
                            break;

                        case (int)MyEnum.Menu.CreateEmployee:
                            break;

                        case (int)MyEnum.Menu.UpdateEmployee:
                            break;

                        case (int)MyEnum.Menu.GetEmployeeByID:
                            break;

                        case (int)MyEnum.Menu.DeleteEmployee:
                            break;

                        case (int)MyEnum.Menu.GetEmployeeByAge:
                            break;

                        case (int)MyEnum.Menu.GetAllEmployeeByCompanyID:
                            break;
                    }
                    
                }
                else
                {
                    goto EnterOption;
                }
                       
            }

        }
        private static void ShowMenu()
        {
            Helpers.WriteToConsole(ConsoleColor.DarkMagenta, "1 - Create Company    4 - Get Company by ID             7 - Create Employee     10 - Delete Employee\n");
            Helpers.WriteToConsole(ConsoleColor.DarkMagenta, "2 - Update Company    5 - Get All Companies by Name     8 - Update Employee     11 - Get Employee by Age\n");
            Helpers.WriteToConsole(ConsoleColor.DarkMagenta, "3 - Delete Company    6 - Get All Companies             9 - Get Employee by ID  12 - Get All Employes by Company ID\n");

        }
    }
   
}
                    
            
            

            

            

