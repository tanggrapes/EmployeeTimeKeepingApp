using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTimeKeepingApp.Entities
{
    public class TimeKeepingTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeKeepingTransactionId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Employee is required")]
        public int EmployeeId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Transaction Type is required")]
        [Display(Name = "Transaction Type")]
        public int TransactionTypeId { get; set; }
        [Required]
        [Display(Name = "Transaction Date")]
        [DataType(DataType.DateTime)]
        public DateTime TransactionDateTime { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("TransactionTypeId")]
        public virtual TransactionType TransactionType { get; set; }
    }
}
