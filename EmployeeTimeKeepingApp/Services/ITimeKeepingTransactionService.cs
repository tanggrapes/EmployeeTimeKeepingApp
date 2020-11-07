using EmployeeTimeKeepingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.Services
{
    public interface ITimeKeepingTransactionService
    {

        Task<List<TimeKeepingTransaction>> GetTimeKeepingTransactions(int pageSize, int page);
        Task<int> Create(TimeKeepingTransaction timeKeepingTransaction);
        Task<int> Count();
        Task<int> CountByEmployee(int employeeId);
        Task<List<TimeKeepingTransaction>> GetTimeKeepingTransactionsByEmployee(int pageSize, int page, int employeeId);
    }
}
