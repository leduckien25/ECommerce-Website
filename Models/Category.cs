using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMvc.Models;

public partial class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public short CategoryId { get; set; }
    [MaxLength(64)]
    [Required]
    public string CategoryName { get; set; } = null!;

    [MaxLength(2024)]
    public string? Description { get; set; }

    [MaxLength(32)]

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
