using EmployeeTimeKeepingApp.Entities;
using EmployeeTimeKeepingApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public EmployeeService(IApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public Task<int> Create(Employee employee)
        {
            _applicationDbContext.Employees.AddAsync(employee);
            return _applicationDbContext.SaveChangesAsync();
        }

        public Task<int> Delete(int id)
        {
            var employee = _applicationDbContext.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            _applicationDbContext.Employees.Remove(employee);
            return _applicationDbContext.SaveChangesAsync();
        }

        public Task<Employee> GetById(int id)
        {
            return _applicationDbContext.Employees.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();
        }

        public Task<List<Employee>> GetEmployees(int pageSize, int page)
        {
            return _applicationDbContext.Employees.Skip(pageSize * page).Take(pageSize).ToListAsync();
        }

        public Task<int> Count()
        {
            return _applicationDbContext.Employees.CountAsync();
        }

        public Task<int> Update(Employee obj)
        {
            var employee = _applicationDbContext.Employees.Where(e => e.EmployeeId == obj.EmployeeId).FirstOrDefault();
            employee.FirstName = obj.FirstName;
            employee.LastName = obj.LastName;
            employee.Gender = obj.Gender;
            employee.DateHired = obj.DateHired;
            return  _applicationDbContext.SaveChangesAsync();
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            return _applicationDbContext.Employees.ToListAsync();
        }
    }
}
