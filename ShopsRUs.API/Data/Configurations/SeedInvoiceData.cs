using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUs.API.Models.Entities;
using System;

namespace ShopsRUs.API.Data.Configurations
{
    public class SeedInvoiceData : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            // For Customer
            builder.HasData(new Invoice
            {
                Id = 1,
                OrderId = 1,
                InvoiceNumber = "A001",
                UserId = 1,
                Total = 500,
                CreatedOnDate = DateTime.Now
            });

            // For Customer
            builder.HasData(new Invoice
            {
                Id = 2,
                OrderId = 2,
                InvoiceNumber = "A002",
                UserId = 2,
                Total = 1500,
                CreatedOnDate = DateTime.Now
            });

            // For Affiliate
            builder.HasData(new Invoice
            {
                Id = 3,
                OrderId = 3,
                InvoiceNumber = "A003",
                UserId = 3,
                Total = 990,
                CreatedOnDate = DateTime.Now
            });

            // For Employee
            builder.HasData(new Invoice
            {
                Id = 4,
                OrderId = 4,
                InvoiceNumber = "A004",
                UserId = 4,
                Total = 920,
                CreatedOnDate = DateTime.Now
            });
        }
    }
}
