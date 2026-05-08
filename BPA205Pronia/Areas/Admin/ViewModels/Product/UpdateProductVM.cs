namespace BPA205Pronia.Areas.Admin.ViewModels.Product
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> TagIds { get; set; }
    }
}
