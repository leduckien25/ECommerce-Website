using WebApplicationMvc.Models;

namespace WebApplicationMvc.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart? GetCartWithItems(string userId);

        void AddCartItem(string userId, int productId, int quantity);

        int GetItemCount(string userId);

        decimal GetTotalAmount(string userId);

        void RemoveCartItem(int cartItemId);

        void ClearCartByUserId(string userId);
    }
}
