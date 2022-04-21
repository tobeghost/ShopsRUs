using System.ComponentModel.DataAnnotations;

namespace ShopsRUs.API.Models.DTOs
{
    public class CreateDiscountDto
    {
        [Required(ErrorMessage = "The name field is required.")]
        [MaxLength(25, ErrorMessage = "Max length for the name field is {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The type field is required.")]
        [MaxLength(25, ErrorMessage = "Max length for the type field is {0}")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The rate field is required.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "The rate cannot be a negative number")]
        public decimal Rate { get; set; }

        public bool IsRatePercentage { get; set; }
    }
}
