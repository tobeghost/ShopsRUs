using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.API.Services
{
    public interface IDiscountService
    {
        void CreateDiscount(Discounts discount);
        string GetDiscountPercentage(Discounts discount);
        Task<IEnumerable<Discounts>> GetAllDiscounts();
        Task<Discounts> GetDiscountPercentageByType(DiscountType type);
    }
}
