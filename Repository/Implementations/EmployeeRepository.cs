using Domain.Models;
using Repository.Database;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee employee)
        {
            try
            {
                if (employee == null)
                    throw new CustomException("Company is null");
                ApplicationDbContext<Employee>.database.Add(employee);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Employee employee)
        {
           try
           {
                ApplicationDbContext<Employee>.database.Remove(employee);
                return true;

           }
           catch (Exception ex)
           {
                Console.WriteLine(ex.Message);
                return false;
           }
            
        }

        public Employee Get(Predicate<Employee> filter)
        {
            if (filter == null)
                throw new CustomException("Filter is not Detected");

            return filter == null ? null : ApplicationDbContext<Employee>.database.Find(filter);
        }

        public List<Employee> GetAll(Predicate<Employee> filter)
        {
            try
            {
                return filter == null ? ApplicationDbContext<Employee>.database : ApplicationDbContext<Employee>.database.FindAll(filter);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Update(Employee employee)
        {
            try
            {
                var getResult = Get(m => m.ID == employee.ID);

                if (getResult != null)
                {
                    if (!string.IsNullOrEmpty(employee.Name))
                        getResult.Name = employee.Name;

                    if (!string.IsNullOrEmpty(employee.Surname))
                        getResult.Surname = employee.Surname;

                    

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
