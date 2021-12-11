using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Item : IEntity
    {
        [Key]
        public int ItemId { get; set; }
        [MaxLength(50)]
        public string Borrower { get; set; }
        [MaxLength(50)]
        public string Lender { get; set; }
        [MaxLength(50)]
        public string ItemName { get; set; }
    }
}
