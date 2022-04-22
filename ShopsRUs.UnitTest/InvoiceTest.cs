using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopsRUs.API;
using ShopsRUs.API.Controllers;
using ShopsRUs.API.Models.DTOs;
using ShopsRUs.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRUs.UnitTest
{
    public class InvoiceTest
    {
        private readonly HttpClient _client;

        public InvoiceTest()
        {
            var config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", false, true).Build();
            var host = new WebHostBuilder().UseStartup<Startup>().UseConfiguration(config);
            var server = new TestServer(host);
            _client = server.CreateClient();
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsAllCustomers()
        {
            //Act
            var result = await _client.GetAsync("api/customers");

            result.EnsureSuccessStatusCode();

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public async Task WhenCalled_CreateInvoiceForEmployee(int userId)
        {
            var randomNumber = new Random().Next(0, 10000).ToString();
            var invoiceNumber = $"BILL{randomNumber}";

            var invoice = new CreateInvoiceDto();
            invoice.InvoiceNumber = invoiceNumber;
            invoice.OrderTotal = 38;
            invoice.InvoiceDetails = new List<InvoiceDetails>();
            invoice.InvoiceDetails.Add(new InvoiceDetails()
            {
                ProductId = 1,
                ProductName = "Invoice Item",
                ProductPrice = 20,
                ProductQuantity = 2,
                DerivedProductCost = 40,
                DiscountPrice = 2,
                TotalDerivedCost = 38,
                CreatedOnDate = DateTime.Now
            });

            var body = new StringContent(JsonConvert.SerializeObject(invoice), Encoding.UTF8, "application/json");

            //Act
            var result = await _client.PostAsync($"api/invoices?userId={userId}", body);

            result.EnsureSuccessStatusCode();

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var invoiceResult = await _client.GetAsync($"api/invoices/{invoiceNumber}");
            invoiceResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var total = await invoiceResult.Content.ReadAsStringAsync();

            Assert.Equal(26.6M, Convert.ToDecimal(total, new CultureInfo("en-US")));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task WhenCalled_CreateInvoiceForCustomer(int userId)
        {
            var randomNumber = new Random().Next(0, 10000).ToString();
            var invoiceNumber = $"BILL{randomNumber}";

            var invoice = new CreateInvoiceDto();
            invoice.InvoiceNumber = invoiceNumber;
            invoice.OrderTotal = 38;
            invoice.InvoiceDetails = new List<InvoiceDetails>();
            invoice.InvoiceDetails.Add(new InvoiceDetails()
            {
                ProductId = 1,
                ProductName = "Invoice Item",
                ProductPrice = 20,
                ProductQuantity = 2,
                DerivedProductCost = 40,
                DiscountPrice = 2,
                TotalDerivedCost = 38,
                CreatedOnDate = DateTime.Now
            });

            var body = new StringContent(JsonConvert.SerializeObject(invoice), Encoding.UTF8, "application/json");

            //Act
            var result = await _client.PostAsync($"api/invoices?userId={userId}", body);

            result.EnsureSuccessStatusCode();

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var invoiceResult = await _client.GetAsync($"api/invoices/{invoiceNumber}");
            invoiceResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var total = await invoiceResult.Content.ReadAsStringAsync();

            Assert.Equal(36.10M, Convert.ToDecimal(total, new CultureInfo("en-US")));
        }

        [Theory]
        [InlineData(3)]
        public async Task WhenCalled_CreateInvoiceForAffiliate(int userId)
        {
            var randomNumber = new Random().Next(0, 10000).ToString();
            var invoiceNumber = $"BILL{randomNumber}";

            var invoice = new CreateInvoiceDto();
            invoice.InvoiceNumber = invoiceNumber;
            invoice.OrderTotal = 38;
            invoice.InvoiceDetails = new List<InvoiceDetails>();
            invoice.InvoiceDetails.Add(new InvoiceDetails()
            {
                ProductId = 1,
                ProductName = "Invoice Item",
                ProductPrice = 20,
                ProductQuantity = 2,
                DerivedProductCost = 40,
                DiscountPrice = 2,
                TotalDerivedCost = 38,
                CreatedOnDate = DateTime.Now
            });

            var body = new StringContent(JsonConvert.SerializeObject(invoice), Encoding.UTF8, "application/json");

            //Act
            var result = await _client.PostAsync($"api/invoices?userId={userId}", body);

            result.EnsureSuccessStatusCode();

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var invoiceResult = await _client.GetAsync($"api/invoices/{invoiceNumber}");
            invoiceResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var total = await invoiceResult.Content.ReadAsStringAsync();

            Assert.Equal(34.20M, Convert.ToDecimal(total, new CultureInfo("en-US")));
        }
    }
}
