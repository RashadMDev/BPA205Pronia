using Microsoft.AspNetCore.Identity;

namespace BPA205Pronia.Areas.Admin.ViewModels.Account.Admin
{
    public record CreateAdminVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
