using EmployeeTimeKeepingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.Services
{
    public interface IEmployeeService
    {

        Task<List<Employee>> GetEmployees(int pageSize, int page);

        Task<List<Employee>> GetAllEmployees();
        Task<int> Create(Employee employee);
        Task<int> Update(Employee id);
        Task<int> Delete(int id);

        Task<int> Count();
        Task<Employee> GetById(int id);
    }
}
