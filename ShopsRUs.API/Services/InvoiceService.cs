using Microsoft.EntityFrameworkCore;
using ShopsRUs.API.Data;
using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly Repository<Invoice> _invoiceRepository;

        public InvoiceService(Repository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public void GenerateInvoiceForCustomer(int userId, Invoice invoice)
        {
            invoice.UserId = userId;
            _invoiceRepository.Add(invoice);
        }

        public async Task<Invoice> GetTotalInvoiceAmount(string billNumber)
        {
            return await _invoiceRepository.Find(i => i.InvoiceNumber.Equals(billNumber)).FirstOrDefaultAsync();
        }
    }
}
