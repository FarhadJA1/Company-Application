using Domain.Models;
using Service.Services;
using Service.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class CompanyController
    {
        private CompanyService companyService;
        public CompanyController()
        {
            companyService = new CompanyService();
        }

        public void Create()
        {
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Company Name:");
            string companyName = Console.ReadLine();
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Company Address:");
            string address = Console.ReadLine();
            Company company = new Company();
            company.Name = companyName;
            company.Address = address;

            var createResult = companyService.Create(company);
            if (createResult != null)
            {
                Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{company.ID}. Company Name: {companyName} , Addess: {company.Address} - was Successfully Created !\n");
            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Red, "Something Went Wrong !\n");
            }
        }

        public void GetByID()
        {
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
                    Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{getIdResult.ID}. Company Name: {getIdResult.Name}, Address: {getIdResult.Address} - was Successfully Found !\n");
                }

            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Red, "Try Again !\n");
                goto EnterID;
            }
        }

        public void Delete()
        {
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
                    companyService.Delete(getIdResult);
                    Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{getIdResult.ID}. Company Name: {getIdResult.Name}, Address: {getIdResult.Address} - was Successfully Deleted !\n");
                }

            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Red, "Try Again !\n");
                goto EnterID;
            }
        }

        public void GetAllByName()
        {
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Company Name:\n");
            EnterName: string name = Console.ReadLine();

            
            var companyNames= companyService.GetAllCompaniesByName(name);

            if (name == null)
            {
                Helpers.WriteToConsole(ConsoleColor.Red, "Company was not Found !\n");
                goto EnterName;
            }
            else
            {
                foreach (var item in companyNames)
                {
                    Helpers.WriteToConsole(ConsoleColor.Green, $"{item.ID}. Company Name: {item.Name}, Address: {item.Address}\n");
                }
                
            }

        }
        public void GetAllCompanies()
        {
            var allCompanies = companyService.GetAllCompanies();

            foreach (var item in allCompanies)
            {
                Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{item.ID}. Company Name: {item.Name}, Address: {item.Address}\n");
            }
        }

        public void Update()
        {
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add Company ID:\n");

            EnterID: string companyID = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyID, out id);

            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add new Company Name:\n");
            string newName = Console.ReadLine();
            Helpers.WriteToConsole(ConsoleColor.DarkCyan, "Add new Company Address:\n");
            string newAddress = Console.ReadLine();


            if (isIdTrue)
            {
                Company company = new Company();
                company.Name = newName;
                company.Address = newAddress;

                Company newCompany = companyService.Update(id, company);

                Helpers.WriteToConsole(ConsoleColor.DarkGreen, $"{newCompany.Name} was Successfully Updated!\n");


            }
            else
            {
                Helpers.WriteToConsole(ConsoleColor.Red, "Try Again !\n");
                goto EnterID;
            }
        }
        
    }
}
