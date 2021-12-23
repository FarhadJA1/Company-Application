using Domain.Models;
using Repository.Database;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Create(Company company)
        {
            try
            {
                if (company == null)
                    throw new CustomException("Company is null");
                ApplicationDbContext<Company>.database.Add(company);
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void Add(Company entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Company entity)
        {
            throw new NotImplementedException();
        }

        public Company Get(Predicate<Company> filter = null)
        {
            return filter == null ? null : ApplicationDbContext<Company>.database.Find(filter); 
        }

        public List<Company> GetAll(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
