using BPA205Pronia.Models.Base;

namespace BPA205Pronia.Models
{
    public class Image : BaseEntity
    {
        public string Url{ get; set; }
        public bool IsPrimary { get; set; } = false;
        public Product Product { get; set; }
    }
}
