using Domain.Models;
using Repository.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private int Count { get; set; }
        CompanyRepository companyRepository;
        EmployeeRepository employeeRepository;
        public EmployeeService()
        {
            companyRepository = new CompanyRepository();
            employeeRepository = new EmployeeRepository();
        }

        public Employee Create(Employee employee, int companyID)
        {
            try
            {
                Company company = companyRepository.Get(m => m.ID == companyID);
                if(company == null)  return null;
                employee.ID = Count;
                employee.Company = company;
                Count++;
                employeeRepository.Create(employee);
                return employee;
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(Employee employee)
        {
            var deleteResult = employeeRepository.Get(m => m.Name == employee.Name && m.Surname == employee.Surname);
            employeeRepository.Delete(employee);
            return employeeRepository.Delete(employee);
        }

        public List<Employee> GetEmployesByAge(string age)
        {
            try
            {
                return employeeRepository.GetAll(m => m.Age == age);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public List<Employee> GetAllEmployesCompanyID(int id)
        {
            try
            {
                return employeeRepository.GetAll(m => m.Company.ID == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public Employee GetEmployeeByID(int id)
        {
            try
            {
                return employeeRepository.Get(m => m.ID == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public Employee Update(int id, Employee employee)
        {
            try
            {
                var idResult = GetEmployeeByID(id);
                employee.ID = idResult.ID;
                employeeRepository.Update(employee);
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
          
            


        }
        
    }
}
