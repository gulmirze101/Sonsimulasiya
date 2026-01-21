using System.ComponentModel.DataAnnotations;

namespace Sonsimulasiya.ViewModels.UserViewModels
{
    public class LoginVM
    {
    

        [Required, MaxLength(256), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(256), MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


    }
}
