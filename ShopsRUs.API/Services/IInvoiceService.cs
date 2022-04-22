using ShopsRUs.API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.API.Services
{
    public interface IInvoiceService
    {
        void GenerateInvoice(int userId, Invoice invoice);
        void AddInvoiceDetails(int invoiceId, List<InvoiceDetails> invoiceDetails);
        Task<Invoice> GetTotalInvoiceAmount(string billNumber);
    }
}
