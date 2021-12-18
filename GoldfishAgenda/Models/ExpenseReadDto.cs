using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldfishAgenda.Models
{
    public class ExpenseReadDto
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
    }
}
