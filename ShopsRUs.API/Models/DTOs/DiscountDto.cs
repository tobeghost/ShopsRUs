namespace ShopsRUs.API.Models.DTOs
{
    public class DiscountDto
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Rate { get; set; }
        public bool IsRatePercentage { get; set; }
        public string CreatedOnDate { get; set; }
    }
}
