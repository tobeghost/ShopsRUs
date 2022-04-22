using ShopsRUs.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Models.DTOs
{
    public class CreateInvoiceDto
    {
        [Required(ErrorMessage = "Invoice number field is required")]
        [MaxLength(25)]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Order ID field is required")]
        [MaxLength(25)]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Order total field is required")] 
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Order total must be a positive value")]
        public decimal OrderTotal { get; set; }

        public IEnumerable<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
