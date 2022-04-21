using System;

namespace ShopsRUs.API.Models.DTOs
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string CreatedOnDate { get; set; }
    }
}
