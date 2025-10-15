namespace WebApplicationMvc.ViewModels
{
    public class CategoryViewModel
    {
        public short CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int ProductCount { get; set; }

    }
}
