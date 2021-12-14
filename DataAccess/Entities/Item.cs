using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        [MaxLength(50)]
        public string Borrower { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lender { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Item")]
        public string ItemName { get; set; }
    }
}
