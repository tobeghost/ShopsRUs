namespace ShopsRUs.API.Models.DTOs
{
    public class CustomerUsersDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string JoinedIn { get; set; }
    }
}
