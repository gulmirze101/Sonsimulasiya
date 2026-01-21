using Microsoft.AspNetCore.Identity;

namespace Sonsimulasiya.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
