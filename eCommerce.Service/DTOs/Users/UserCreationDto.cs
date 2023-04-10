using eCommerce.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.DTOs.Users
{
    public class UserCreationDto
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
