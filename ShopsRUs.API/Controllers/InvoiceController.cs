using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.API.Models.DTOs;
using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IUserService _userService;
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IUserService userService, IDiscountService discountService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _userService = userService;
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet("{billNumber}")]
        public async Task<IActionResult> GetInvoice(string billNumber)
        {
            if (billNumber == null) return BadRequest();
            var invoice = await _invoiceService.GetTotalInvoiceAmount(billNumber);
            if (invoice == null) return NotFound();
            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);
            return Ok(invoiceDto.Total);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateInvoiceForACustomer(int userId, [FromBody] CreateInvoiceDto invoiceDto)
        {
            var user = await _userService.GetCustomerById(userId);
            if (user == null) return NotFound();

            decimal invoiceSubtotal = 0;
            invoiceSubtotal = await ApplyDiscount(invoiceDto, invoiceSubtotal, user);
            var invoiceEntity = _mapper.Map<Invoice>(invoiceDto);
            invoiceEntity.Total = invoiceSubtotal;
            _invoiceService.GenerateInvoiceForCustomer(userId, invoiceEntity);
            return Ok();
        }

        private async Task<decimal> ApplyDiscount(CreateInvoiceDto invoiceDto, decimal invoiceSubtotal, Users user)
        {
            var discounts = await _discountService.GetAllDiscounts();
            foreach (var discount in discounts)
            {
                if (discount.Equals(user.UserType) && discount.IsRatePercentage)
                {
                    var discountValue = invoiceDto.OrderTotal * (discount.Rate / 100);
                    invoiceSubtotal = invoiceDto.OrderTotal - discountValue;
                }

                foreach (var detail in invoiceDto.InvoiceDetails)
                {
                    if (detail.DerivedProductCost >= 100 && !discount.IsRatePercentage)
                    {
                        invoiceSubtotal -= discount.Rate;
                    }
                }
            }

            return invoiceSubtotal;
        }
    }
}
