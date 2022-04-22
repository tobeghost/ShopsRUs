using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.API.Models.DTOs;
using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Models.Enums;
using ShopsRUs.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var discounts = await _discountService.GetAllDiscounts();
            var discountsDto = _mapper.Map<IEnumerable<DiscountDto>>(discounts);
            return Ok(discountsDto);
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetDiscount(DiscountType type)
        {
            var discount = await _discountService.GetDiscountPercentageByType(type);
            if (discount == null) return NotFound();
            var discountPercentage = _discountService.GetDiscountPercentage(discount);
            if (discountPercentage != null) return Ok(discountPercentage);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDto discountDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var discountEntity = _mapper.Map<Discounts>(discountDto);
            _discountService.CreateDiscount(discountEntity);
            return Ok();
        }
    }
}
