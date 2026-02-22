using WebApplicationMvc.Models;

namespace WebApplicationMvc.Services.Interfaces
{
    public interface ICartService
    {
        Cart? GetCart(string userid);
        int AddItem(string userId, int productId, int quantity);
        int GetItemCount(string userId);
        decimal GetTotalAmount(string userId);
        int RemoveItem(int cartItemId);
        int ClearCart(string userId);
    }
}
