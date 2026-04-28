using BPA205Pronia.Models.Base;

namespace BPA205Pronia.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products{ get; set; }
    }
}
