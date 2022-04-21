using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUs.API.Models.Entities;
using System;

namespace ShopsRUs.API.Data.Configurations
{
    public class SeedInvoiceDetailsData : IEntityTypeConfiguration<InvoiceDetails>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetails> builder)
        {
            // First Customer
            // Only loyal customer discount applied here
            builder.HasData(new InvoiceDetails
            {
                Id = 1,
                InvoiceId = 1,
                ProductId = 2,
                ProductName = "Invoice Item 2",
                ProductPrice = 20,
                ProductQuantity = 2,
                DerivedProductCost = 40,
                DiscountPrice = 2,
                TotalDerivedCost = 38,
                CreatedOnDate = DateTime.Now
            });

            // Only price per $100 discount applied here (given that a percentage based discount has already been applied to this user
            builder.HasData(new InvoiceDetails
            {
                Id = 2,
                InvoiceId = 1,
                ProductId = 4,
                ProductName = "Invoice Item 4",
                ProductPrice = 482,
                ProductQuantity = 1,
                DerivedProductCost = 482,
                DiscountPrice = 20,
                TotalDerivedCost = 462,
                CreatedOnDate = DateTime.Now
            });

            // Second customer (recently joined, and price less than $100)
            // No discount applied
            builder.HasData(new InvoiceDetails
            {
                Id = 3,
                InvoiceId = 2,
                ProductId = 40,
                ProductName = "Invoice Item 40",
                ProductPrice = 50,
                ProductQuantity = 5,
                DerivedProductCost = 250,
                DiscountPrice = 0,
                TotalDerivedCost = 250,
                CreatedOnDate = DateTime.Now
            });

            // Affiliate
            // Only affiliate discount applied here
            builder.HasData(new InvoiceDetails
            {
                Id = 4,
                InvoiceId = 3,
                ProductId = 3,
                ProductName = "Invoice Item 3",
                ProductPrice = 50,
                ProductQuantity = 5,
                DerivedProductCost = 250,
                DiscountPrice = 25,
                TotalDerivedCost = 225,
                CreatedOnDate = DateTime.Now
            });

            // Only price per $100 discount applied here (given that a percentage based discount has already been applied to this user
            builder.HasData(new InvoiceDetails
            {
                Id = 5,
                InvoiceId = 3,
                ProductId = 5,
                ProductName = "Invoice Item 5",
                ProductPrice = 400,
                ProductQuantity = 1,
                DerivedProductCost = 400,
                DiscountPrice = 20,
                TotalDerivedCost = 380,
                CreatedOnDate = DateTime.Now
            });

            // No discount applied due to:
            // This user has already had the affiliate discount applied and price is less than $100
            builder.HasData(new InvoiceDetails
            {
                Id = 6,
                InvoiceId = 3,
                ProductId = 15,
                ProductName = "Invoice Item 15",
                ProductPrice = 77,
                ProductQuantity = 5,
                DerivedProductCost = 385,
                DiscountPrice = 0,
                TotalDerivedCost = 385,
                CreatedOnDate = DateTime.Now
            });

            // Both the percentage based discount and price based discount is applied to this user
            builder.HasData(new InvoiceDetails
            {
                Id = 7,
                InvoiceId = 4,
                ProductId = 105,
                ProductName = "Invoice Item 105",
                ProductPrice = 200,
                ProductQuantity = 5,
                DerivedProductCost = 1000,
                DiscountPrice = 80,
                TotalDerivedCost = 920,
                CreatedOnDate = DateTime.Now
            });
        }
    }
}
