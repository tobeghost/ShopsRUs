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
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CustomerController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _userService.GetAllCustomers();
            var customerDto = _mapper.Map<IEnumerable<CustomerUsersDto>>(customers);
            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomers([FromBody] CreateCustomerUserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userEntity = _mapper.Map<Users>(userDto);
            _userService.CreateUser(userEntity, UserType.Customer);

            var customerToReturn = _mapper.Map<CustomerUsersDto>(userEntity);
            return CreatedAtRoute("CustomerId", new { Id = customerToReturn.UserId }, customerToReturn);
        }

        [HttpGet("{id:int}", Name = "CustomerId")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _userService.GetCustomerById(id);
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<CustomerUsersDto>(customer);
            return Ok(customerDto);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            var customer = await _userService.GetCustomersByName(name.Trim().ToLower());
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<CustomerUsersDto>(customer);
            return Ok(customerDto);
        }
    }
}
