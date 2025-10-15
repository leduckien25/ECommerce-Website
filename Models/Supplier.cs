using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMvc.Models;
public partial class Supplier
{
    [MaxLength(16)]
    [Key]
    public string SupplierId { get; set; } = null!;

    [MaxLength(64)]
    [Required]
    public string SupplierName { get; set; } = null!;

    [MaxLength(64)]
    [Required]
    public string Email { get; set; } = null!;

    [MaxLength(16)]
    public string? Phone { get; set; }

    [MaxLength(64)]
    public string? Address { get; set; }

    [MaxLength(1024)]
    public string? Description { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}
