using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Expense : IEntity
    {
        [Key]
        public int ExpenseId { get; set; }
        [MaxLength(100)]
        public string ExpenseName { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
