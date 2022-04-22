using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsRUs.API.Models.Entities
{
    [Table("Invoice")]
    public class Invoice : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(25)]
        public string InvoiceNumber { get; set; }

        [Required]
        [MaxLength(25)]
        public int OrderId { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }

        [Required]
        public decimal Total { get; set; }
    }
}
