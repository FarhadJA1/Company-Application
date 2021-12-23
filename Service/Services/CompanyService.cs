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
            throw new NotImplementedException();
        }

        public List<Company> GetAllCompanies(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAllCompaniesByName(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyByID(int id)
        {
            return companyRepository.Get(m => m.ID == id);
            
            
        }

        public Company Update(string name, string address)
        {
            throw new NotImplementedException();
        }
    }
}
