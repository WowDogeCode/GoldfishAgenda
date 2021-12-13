using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        [DisplayName("Expense")]
        [MaxLength(100)]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount value must be greater than 0")]
        public int Amount { get; set; }
    }
}
