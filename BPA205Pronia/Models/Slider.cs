using BPA205Pronia.Models.Base;

namespace BPA205Pronia.Models
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImageUrl { get; set; }
        public int Discount { get; set; }
    }
}
