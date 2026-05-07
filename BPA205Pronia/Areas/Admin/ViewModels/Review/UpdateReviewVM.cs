using System.ComponentModel.DataAnnotations;

namespace BPA205Pronia.Areas.Admin.ViewModels.Review
{
    public class UpdateReviewVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, ErrorMessage = "Username must be max 20 characters"), MinLength(3, ErrorMessage = "Username must be min 3 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        [StringLength(200, ErrorMessage = "Comment must be max 200 characters"), MinLength(3, ErrorMessage = "Comment must be min 3 characters")]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }
    }
}
