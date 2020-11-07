using EmployeeTimeKeepingApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.DataAccess
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync();

        Task<IDbContextTransaction> Transaction();
        DbSet<Employee> Employees { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }
        DbSet<TimeKeepingTransaction> TimeKeepingTransactions { get; set; }
    }
}
