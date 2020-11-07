using EmployeeTimeKeepingApp.DataAccess;
using EmployeeTimeKeepingApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public TransactionTypeService(IApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public Task<List<TransactionType>> GetTransactionTypes()
        {
            return _applicationDbContext.TransactionTypes.ToListAsync();
        }
    }
}
