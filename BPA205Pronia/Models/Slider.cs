using BPA205Pronia.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPA205Pronia.Models
{
    public class Slider : BaseEntity
    {
        //Title Validation
        [Required(ErrorMessage = "Title is required...")]
        [
            StringLength(30, ErrorMessage = "Title must be maximum 30 characters.."),
            MinLength(3, ErrorMessage = "Title must be at least 3 characters")
        ]
        public string Title { get; set; }


        //Description Validation
        [Required(ErrorMessage = "Description is required...")]
        [
            StringLength(150, ErrorMessage = "Title must be maximum 150 characters.."),
            MinLength(10, ErrorMessage = "Title must be at least 10 characters")
        ]
        public string Desc { get; set; }


        //Image
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


        //Discount Validation
        [Required(ErrorMessage = "Discount is required...")]
        [Range(0,100, ErrorMessage = "Discount must be between 0-100")]
        public int Discount { get; set; }
    }
}

