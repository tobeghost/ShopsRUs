using Microsoft.EntityFrameworkCore;
using ShopsRUs.API.Data;
using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IRepository<InvoiceDetails> _invoiceDetailRepository;

        public InvoiceService(IRepository<Invoice> invoiceRepository, IRepository<InvoiceDetails> invoiceDetailRepository)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public void GenerateInvoice(int userId, Invoice invoice)
        {
            invoice.UserId = userId;
            invoice.CreatedOnDate = DateTime.Now;
            _invoiceRepository.Add(invoice);
        }

        public void AddInvoiceDetails(int invoiceId, List<InvoiceDetails> invoiceDetails)
        {
            invoiceDetails.ForEach(i => i.InvoiceId = invoiceId);

            _invoiceDetailRepository.AddRange(invoiceDetails);
        }

        public async Task<Invoice> GetTotalInvoiceAmount(string billNumber)
        {
            return await _invoiceRepository.Find(i => i.InvoiceNumber.Equals(billNumber)).FirstOrDefaultAsync();
        }
    }
}
