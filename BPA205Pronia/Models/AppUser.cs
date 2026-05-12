using Microsoft.AspNetCore.Identity;

namespace BPA205Pronia.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
