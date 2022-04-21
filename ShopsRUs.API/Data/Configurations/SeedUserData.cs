using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Models.Enums;
using System;

namespace ShopsRUs.API.Data.Configurations
{
    public class SeedUserData : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(new Users
            {
                Id = 1,
                FirstName = "İsmail",
                LastName = "AKTI",
                Email = "iismailakti@gmail.com",
                PhoneNumber = "123456789",
                UserType = UserType.Customer,
                CreatedOnDate = DateTime.Now.AddYears(-3)
            });

            builder.HasData(new Users
            {
                Id = 2,
                FirstName = "Mehmet",
                LastName = "KAPLAN",
                Email = "user2@email.com",
                PhoneNumber = "12345678910",
                UserType = UserType.Customer,
                CreatedOnDate = DateTime.Now.AddMonths(-3)
            });

            builder.HasData(new Users
            {
                Id = 3,
                FirstName = "Penny",
                LastName = "Jackson",
                Email = "user3@email.com",
                PhoneNumber = "123456789",
                UserType = UserType.Affiliate,
                CreatedOnDate = DateTime.Now.AddYears(-1)
            });

            builder.HasData(new Users
            {
                Id = 4,
                FirstName = "Amy",
                LastName = "Fowler",
                Email = "user4@email.com",
                PhoneNumber = "123456789",
                UserType = UserType.Employee,
                CreatedOnDate = DateTime.Now.AddYears(-5)
            });

            builder.HasData(new Users
            {
                Id = 5,
                FirstName = "Raj",
                LastName = "Koothrappali",
                Email = "user5@email.com",
                PhoneNumber = "123456789",
                UserType = UserType.Employee,
                CreatedOnDate = DateTime.Now.AddYears(-3)
            });
        }
    }
}
