using ExpensesManagement.api.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManagement.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        
        public DbSet<User> Users { get; set; }
        public DbSet<TaxExemption> TaxExemptions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<FinalTax> FinalTaxes { get; set; }
    }
}