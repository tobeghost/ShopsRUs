using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRUs.API.Migrations
{
    public partial class InitialContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRatePercentage = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderId = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 30, nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    DerivedProductCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDerivedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CreatedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedOnDate", "IsRatePercentage", "Name", "Rate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Employee Discount", 30m, 2 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Affiliate Discount", 10m, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Loyal Customer Discount", 5m, 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Price Discount", 5m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "Id", "CreatedOnDate", "InvoiceNumber", "OrderId", "OrderTotal", "Total", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 22, 10, 34, 27, 82, DateTimeKind.Local).AddTicks(6838), "A001", 1, 0m, 500m, 1 },
                    { 2, new DateTime(2022, 4, 22, 10, 34, 27, 82, DateTimeKind.Local).AddTicks(6996), "A002", 2, 0m, 1500m, 2 },
                    { 3, new DateTime(2022, 4, 22, 10, 34, 27, 82, DateTimeKind.Local).AddTicks(7002), "A003", 3, 0m, 990m, 3 },
                    { 4, new DateTime(2022, 4, 22, 10, 34, 27, 82, DateTimeKind.Local).AddTicks(7005), "A004", 4, 0m, 920m, 4 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "Id", "CreatedOnDate", "DerivedProductCost", "DiscountPrice", "InvoiceId", "ProductId", "ProductName", "ProductPrice", "ProductQuantity", "TotalDerivedCost" },
                values: new object[,]
                {
                    { 7, new DateTime(2022, 4, 22, 10, 34, 27, 83, DateTimeKind.Local).AddTicks(6529), 1000m, 80m, 4, 105, "Invoice Item 105", 200m, 5, 920m },
                    { 6, new DateTime(2022, 4, 22, 10, 34, 27, 83, DateTimeKind.Local).AddTicks(6526), 385m, 0m, 3, 15, "Invoice Item 15", 77m, 5, 385m },
                    { 5, new DateTime(2022, 4, 22, 10, 34, 27, 83, DateTimeKind.Local).AddTicks(6521), 400m, 20m, 3, 5, "Invoice Item 5", 400m, 1, 380m },
                    { 2, new DateTime(2022, 4, 22, 10, 34, 27, 83, DateTimeKind.Local).AddTicks(6504), 482m, 20m, 1, 4, "Invoice Item 4", 482m, 1, 462m },
                    { 3, new DateTime(2022, 4, 22, 10, 34, 27, 83, DateTimeKind.Local).AddTicks(6514), 250m, 0m, 2, 40, "Invoice Item 40", 50m, 5, 250m },
                    { 1, new DateTime(2022, 4, 22, 10, 34, 27, 83, DateTimeKind.Local).AddTicks(6304), 40m, 2m, 1, 2, "Invoice Item 2", 20m, 2, 38m },
                    { 4, new DateTime(2022, 4, 22, 10, 34, 27, 83, DateTimeKind.Local).AddTicks(6517), 250m, 25m, 3, 3, "Invoice Item 3", 50m, 5, 225m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedOnDate", "Email", "FirstName", "LastName", "PhoneNumber", "UserType" },
                values: new object[,]
                {
                    { 4, null, new DateTime(2017, 4, 22, 10, 34, 27, 81, DateTimeKind.Local).AddTicks(6981), "user4@email.com", "Amy", "Fowler", "123456789", 2 },
                    { 1, null, new DateTime(2019, 4, 22, 10, 34, 27, 79, DateTimeKind.Local).AddTicks(7635), "iismailakti@gmail.com", "İsmail", "AKTI", "123456789", 3 },
                    { 2, null, new DateTime(2022, 1, 22, 10, 34, 27, 81, DateTimeKind.Local).AddTicks(6867), "user2@email.com", "Mehmet", "KAPLAN", "12345678910", 3 },
                    { 3, null, new DateTime(2021, 4, 22, 10, 34, 27, 81, DateTimeKind.Local).AddTicks(6973), "user3@email.com", "Penny", "Jackson", "123456789", 1 },
                    { 5, null, new DateTime(2019, 4, 22, 10, 34, 27, 81, DateTimeKind.Local).AddTicks(6984), "user5@email.com", "Raj", "Koothrappali", "123456789", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
