using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GoldfishAgendaDbContext : DbContext
    {
        public GoldfishAgendaDbContext(DbContextOptions<GoldfishAgendaDbContext> options) : base(options) { }
        
        DbSet<Item> Items { get; set; }
        DbSet<Expense> Expenses { get; set; }
    }
}
