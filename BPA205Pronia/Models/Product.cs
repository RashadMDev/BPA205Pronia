using BPA205Pronia.Models.Base;

namespace BPA205Pronia.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Image>? Images { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
