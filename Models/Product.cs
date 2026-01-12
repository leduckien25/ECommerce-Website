using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMvc.Models;

public partial class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [MaxLength(50)]
    [Required]
    public string ProductName { get; set; } = null!;

    [Required]
    public short CategoryId { get; set; }

    [MaxLength(50)]
    public string? Unit { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    [MaxLength(50)]
    public string? ImageUrl { get; set; }

    [Column(TypeName = "datetime")]
    [Required]
    public DateTime DateOfManufacture { get; set; }
    public string? Description { get; set; }

    [MaxLength(16)]
    [Required]
    public string SupplierId { get; set; } = null!;

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey(nameof(SupplierId))]
    public virtual Supplier Supplier { get; set; } = null!;
}
