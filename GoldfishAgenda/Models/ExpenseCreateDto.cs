using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldfishAgenda.Models
{
    public class ExpenseCreateDto
    {
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
    }
}
