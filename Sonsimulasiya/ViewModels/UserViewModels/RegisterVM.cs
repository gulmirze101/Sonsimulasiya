using System.ComponentModel.DataAnnotations;

namespace Sonsimulasiya.ViewModels.UserViewModels
{
    public class RegisterVM
    {
        [Required, MaxLength(256), MinLength(3)]
        public string FullName { get; set; } = string.Empty;
        [Required, MaxLength(256), MinLength(3)]
        public string UserName { get; set; } = string.Empty;

        [Required, MaxLength(256), EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required, MaxLength(256), MinLength(8),DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required, MaxLength(256), MinLength(8),DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
     

    }
}
