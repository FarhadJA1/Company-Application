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

        public void Delete(Employee employee)
        {
            var deleteResult = employeeRepository.Get(m => m.Name == employee.Name && m.Surname == employee.Surname);
            employeeRepository.Delete(employee);
        }

        public List<Employee> GetAllEmployes()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployesByName(string name)
        {
            throw new NotImplementedException();
        }


        public Employee GetEmployeeByID(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
        
    }
}
