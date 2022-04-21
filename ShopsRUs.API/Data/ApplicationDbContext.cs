using Microsoft.EntityFrameworkCore;
using ShopsRUs.API.Data.Configurations;
using ShopsRUs.API.Models.Entities;

namespace ShopsRUs.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Create example data for users
            modelBuilder.ApplyConfiguration(new SeedUserData());

            //Create example data for discounts
            modelBuilder.ApplyConfiguration(new SeedDiscountData());

            //Create example data for invoices
            modelBuilder.ApplyConfiguration(new SeedInvoiceData());

            //Create example data for invoice details
            modelBuilder.ApplyConfiguration(new SeedInvoiceDetailsData());
        }
    }
}
