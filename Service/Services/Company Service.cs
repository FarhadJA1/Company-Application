using Domain.Models;
using Repository.Implementations;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    class Company_Service : ICompanyService
    {
        private CompanyRepository companyRepository;
        public Company_Service()
        {
            companyRepository = new CompanyRepository();
        }
        public Company Create(Company company)
        {
            throw new NotImplementedException();
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

        public Company GetCompanyByID(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public Company Update(string name, string address)
        {
            throw new NotImplementedException();
        }
    }
}
