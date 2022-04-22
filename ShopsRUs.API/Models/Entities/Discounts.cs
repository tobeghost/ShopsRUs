using ShopsRUs.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsRUs.API.Models.Entities
{
    [Table("Discounts")]
    public partial class Discounts : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public DiscountType Type { get; set; }

        [Required]
        public decimal Rate { get; set; }

        public bool IsRatePercentage { get; set; }
    }
}
