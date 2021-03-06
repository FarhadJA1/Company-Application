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


        public bool Delete(Company company)
        {
            try
            {
                ApplicationDbContext<Company>.database.Remove(company);
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Company Get(Predicate<Company> filter = null)
        {
            if (filter == null)
                throw new CustomException("Filter is not Detected");
            
            return filter == null ? null : ApplicationDbContext<Company>.database.Find(filter);
           
                
        }

        public List<Company> GetAll(Predicate<Company> filter)
        {
            
            try
            {
                return filter == null ? ApplicationDbContext<Company>.database : ApplicationDbContext<Company>.database.FindAll(filter);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Update(Company company)
        {
            try
            {
                var getResult = Get(m => m.ID == company.ID);
                
                if(getResult != null)
                {
                    if(!string.IsNullOrEmpty(company.Name))
                        getResult.Name = company.Name;

                    if (!string.IsNullOrEmpty(company.Address))
                        getResult.Address = company.Address;

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
