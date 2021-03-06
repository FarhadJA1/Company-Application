using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ICompanyService
    {
        Company Create(Company company);
        Company Update(int id, Company company);
        void Delete(Company company);
        Company GetCompanyByID(int id);
        List<Company> GetAllCompaniesByName(string name);
        List<Company> GetAllCompanies();


    }
}
