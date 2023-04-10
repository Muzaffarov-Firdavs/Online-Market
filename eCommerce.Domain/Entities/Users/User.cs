using eCommerce.Domain.Commons;
using eCommerce.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public DateTime OrderTime { get; set; }
        public PaymentType Payment { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [MinLength(8)]
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
