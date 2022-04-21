using Microsoft.EntityFrameworkCore;
using ShopsRUs.API.Data;
using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Services
{
    public partial class DiscountService : IDiscountService
    {
        private readonly Repository<Discounts> _discountRepository;

        public DiscountService(Repository<Discounts> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public void CreateDiscount(Discounts discount)
        {
            _discountRepository.Add(discount);
        }

        public string GetDiscountPercentage(Discounts discount)
        {
            if (discount.IsRatePercentage) return $"{discount.Rate}%";
            return null;
        }

        public async Task<IEnumerable<Discounts>> GetAllDiscounts()
        {
            return await _discountRepository.Find().OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Discounts> GetDiscountPercentageByType(DiscountType type)
        {
            return await _discountRepository.Find(d => d.Type == type).FirstOrDefaultAsync();
        }
    }
}
