using Microsoft.EntityFrameworkCore;
using ShopsRUs.API.Data;
using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Services
{
    public class UserService
    {
        private readonly Repository<Users> _userRepository;

        public UserService(Repository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(Users user, UserType userType)
        {
            user.UserType = userType;
            _userRepository.Add(user);
        }

        public async Task<Users> GetUserById(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<IEnumerable<Users>> GetAllCustomers()
        {
            return await _userRepository.Find(u => u.UserType == UserType.Customer).ToListAsync();
        }

        public async Task<Users> GetCustomerById(int customerId)
        {
            return await _userRepository.Find(c => c.Id.Equals(customerId) && c.UserType == UserType.Customer).FirstOrDefaultAsync();
        }

        public async Task<Users> GetCustomersByName(string name)
        {
            return await _userRepository.Find(c => c.LastName.Trim().ToLower().Contains(name) || c.FirstName.Trim().ToLower().Contains(name) && c.UserType == UserType.Customer).FirstOrDefaultAsync();
        }
    }
}
