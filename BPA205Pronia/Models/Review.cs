using BPA205Pronia.Models.Base;

namespace BPA205Pronia.Models
{
    public class Review : BaseEntity
    {
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Product Product { get; set; }
    }
}
