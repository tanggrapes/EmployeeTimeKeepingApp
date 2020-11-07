using EmployeeTimeKeepingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.Services
{
    public interface ITransactionTypeService
    {
        Task<List<TransactionType>> GetTransactionTypes();
    }
}
