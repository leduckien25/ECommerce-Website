using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMvc.Models;

public class Cart
{
    public int CartId { get; set; }
    public string UserId { get; set; }
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
}
