using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsRUs.API.Models.Entities
{
    [Table("InvoiceDetails")]
    public class InvoiceDetails : BaseEntity
    {
        [Required]
        public int InvoiceId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public decimal DerivedProductCost { get; set; }

        public decimal DiscountPrice { get; set; }

        [Required]
        public decimal TotalDerivedCost { get; set; }
    }
}
