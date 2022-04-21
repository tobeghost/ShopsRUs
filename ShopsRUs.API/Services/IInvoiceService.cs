using ShopsRUs.API.Models.Entities;
using System.Threading.Tasks;

namespace ShopsRUs.API.Services
{
    public interface IInvoiceService
    {
        void GenerateInvoiceForCustomer(int userId, Invoice invoice);
        Task<Invoice> GetTotalInvoiceAmount(string billNumber);
    }
}
