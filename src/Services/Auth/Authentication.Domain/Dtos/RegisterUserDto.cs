using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Domain.Dtos
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Last name can only contain English letters.")]
        [DefaultValue("string")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Firstname must be between 3 and 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Last name can only contain English letters.")]
        [DefaultValue("string")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Lastname must be between 3 and 30 characters.")]
        public string LastName { get; set; }

        [DefaultValue("Test information")]
        public string About { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }
    }
}
