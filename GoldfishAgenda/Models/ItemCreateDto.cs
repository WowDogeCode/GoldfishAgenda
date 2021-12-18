using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldfishAgenda.Models
{
    public class ItemCreateDto
    {
        public string Borrower { get; set; }
        public string Lender { get; set; }
        public string ItemName { get; set; }
    }
}
