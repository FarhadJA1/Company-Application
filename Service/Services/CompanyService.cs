using Domain.Models;
using Repository.Implementations;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CompanyService : ICompanyService
    {
        private int Count { get; set; }
        private CompanyRepository companyRepository;
        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }
        public Company Create(Company company)
        {
            company.ID = Count;
            companyRepository.Create(company);
            Count++;
            return company;
        }

        public void Delete(Company company)
        {
            var deleteResult = GetCompanyByID(company.ID);
            companyRepository.Delete(deleteResult);
        }

        public List<Company> GetAllCompaniesByName(string name)
        {
            return companyRepository.GetAll(m => m.Name == name);
        }

        public List<Company> GetAllCompanies()
        {
            return companyRepository.GetAll(null);
        }

        public Company GetCompanyByID(int id)
        {
            return companyRepository.Get(m => m.ID == id);
            
            
        }

        public Company Update(int id, Company company)
        {
            var idResult = GetCompanyByID(id);
            company.ID = idResult.ID;
            companyRepository.Update(company);
            return company;
        }

      
    }
}
