using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee employee, int companyID);
        Employee Update(int id, Employee employee);
        void Delete(Employee employee);
        Employee GetEmployeeByID(int id);
        List<Employee> GetAllEmployesByName(string name);
        List<Employee> GetAllEmployes();
    }
}
