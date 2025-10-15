
namespace WebApplicationMvc.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        
    }
}
