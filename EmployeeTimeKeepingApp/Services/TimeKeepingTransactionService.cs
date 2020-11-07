using EmployeeTimeKeepingApp.DataAccess;
using EmployeeTimeKeepingApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.Services
{
    public class TimeKeepingTransactionService : ITimeKeepingTransactionService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public TimeKeepingTransactionService(IApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public Task<int> Count()
        {
            return _applicationDbContext.TimeKeepingTransactions.CountAsync();
        }

        public Task<int> CountByEmployee(int employeeId)
        {
            return _applicationDbContext.TimeKeepingTransactions.Where(t=> t.EmployeeId == employeeId).CountAsync();
        }

        public Task<int> Create(TimeKeepingTransaction timeKeepingTransaction)
        {
            _applicationDbContext.TimeKeepingTransactions.AddAsync(timeKeepingTransaction);
            return _applicationDbContext.SaveChangesAsync();
        }

        public Task<List<TimeKeepingTransaction>> GetTimeKeepingTransactions(int pageSize, int page)
        {
            return _applicationDbContext.TimeKeepingTransactions.Include(e=> e.Employee).Include(e=>e.TransactionType).Skip(pageSize * page).Take(pageSize).ToListAsync();

        }

        public Task<List<TimeKeepingTransaction>> GetTimeKeepingTransactionsByEmployee(int pageSize, int page, int employeeId)
        {
            return _applicationDbContext.TimeKeepingTransactions.Include(e => e.Employee).Include(e => e.TransactionType).Where(t=> t.EmployeeId == employeeId).Skip(pageSize * page).Take(pageSize).ToListAsync();

        }
    }
}
