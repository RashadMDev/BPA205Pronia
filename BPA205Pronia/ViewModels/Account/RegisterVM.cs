using System.ComponentModel.DataAnnotations;

namespace BPA205Pronia.ViewModels.Account
{
    public record RegisterVM
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, ErrorMessage = "Username cannot exceed 30 characters")]
        [MinLength(2, ErrorMessage = "Username must be contains 2 characters")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        [MinLength(2, ErrorMessage = "Name must be contains 2 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Surname is required")]
        [StringLength(30, ErrorMessage = "Surname cannot exceed 30 characters")]
        [MinLength(2, ErrorMessage = "Surname must be contains 2 characters")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
