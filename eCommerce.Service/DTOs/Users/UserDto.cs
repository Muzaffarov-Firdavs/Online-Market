using eCommerce.Domain.Commons;
using eCommerce.Domain.Enums;

namespace eCommerce.Service.DTOs.Users
{
    public class UserDto : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public DateTime OrderTime { get; set; }
        public PaymentType Payment { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
