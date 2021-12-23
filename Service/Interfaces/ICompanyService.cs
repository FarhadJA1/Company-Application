using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ICompanyService
    {
        Company Create(Company company);
        Company Update(string name, string address);
        void Delete(Company company);
        Company GetCompanyByID(Predicate<Company> filter);
        List<Company> GetAllCompaniesByName(Predicate<Company> filter);
        List<Company> GetAllCompanies(Predicate<Company> filter);


    }
}
