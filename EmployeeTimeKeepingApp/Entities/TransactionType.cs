using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.Entities
{
    public class TransactionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }
        public string TransactionTypName { get; set; }
        public List<TimeKeepingTransaction> TimeKeepingTransactions { get; set; }
    }
}
