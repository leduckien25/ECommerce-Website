using WebApplicationMvc.Models;

namespace WebApplicationMvc.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart? GetCart(string userId);

        void AddToCart(string userId, int productId, int quantity);

        int GetCartItemCount(string userId);

        decimal GetTotalAmount(string userId);

        void Delete(int cartItemId);

        void ClearCart(string userId);
    }
}
