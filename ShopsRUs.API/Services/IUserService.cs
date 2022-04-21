using ShopsRUs.API.Models.Entities;
using ShopsRUs.API.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopsRUs.API.Services
{
    public interface IUserService
    {
        void CreateUser(Users user, UserType userType);
        Task<Users> GetUserById(int userId);
        Task<IEnumerable<Users>> GetAllCustomers();
        Task<Users> GetCustomerById(int customerId);
        Task<Users> GetCustomersByName(string name);
    }
}
