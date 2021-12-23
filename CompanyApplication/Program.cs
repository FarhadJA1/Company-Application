using Domain.Models;
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
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "WELCOME!\n");
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Please, select option:\n");
            CompanyService companyService = new CompanyService();
            while (true)
            {
                Helpers.WriteToConsole(ConsoleColor.DarkMagenta, "1 - Create Company    4 - Get Company by ID             7 - Create Employee     10 - Delete Employee\n");
                Helpers.WriteToConsole(ConsoleColor.DarkMagenta, "2 - Update Company    5 - Get All Companies by Name     8 - Update Employee     11 - Get Employee by Age\n");
                Helpers.WriteToConsole(ConsoleColor.DarkMagenta, "3 - Delete Company    6 - Get All Companies             9 - Get Employee by ID  12 - Get All Employes by Company ID\n");
                
                EnterOption: string selectOption = Console.ReadLine();
                int option;
                bool IsTrueOption = int.TryParse(selectOption, out option);

                if (IsTrueOption)
                {
                    switch (option)
                    {
                        case 1:
                            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Company Name:");
                            string companyName = Console.ReadLine();
                            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Company Address:");
                            string address = Console.ReadLine();
                            Company company = new Company();
                            company.Name = companyName;
                            company.Address = address;

                            var createResult = companyService.Create(company);
                            if(createResult != null)
                            {
                                Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{company.ID} - {companyName} Successfully Created !");
                            }
                            else
                            {
                                Helpers.WriteToConsole(ConsoleColor.Red, "Something Went Wrong !\n");
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Company ID:\n");
                            
                            EnterID: string compID = Console.ReadLine();
                            int id;
                            bool isIdTrue = int.TryParse(compID, out id);
                            
                            if (isIdTrue)
                            {
                                var getIdResult = companyService.GetCompanyByID(id);
                                if (getIdResult == null)
                                {
                                    Helpers.WriteToConsole(ConsoleColor.Red, "Company was not Found !\n");
                                    goto EnterID;
                                }
                                else
                                {
                                    Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{company.ID} - {company.Name} was Successfully Fount !\n");
                                }

                            }
                            else
                            {
                                Helpers.WriteToConsole(ConsoleColor.Red, "Try Again !\n");
                                goto EnterID;
                            }
                            
                           
                            
                            break;
                        
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                    }
                    
                }
                else
                {
                    goto EnterOption;
                }
            
            
            }

            

            


        }
    }
}
