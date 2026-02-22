using WebApplicationMvc.Models;
using WebApplicationMvc.Services.Interfaces;
using WebApplicationMvc.UnitOfWork;

namespace WebApplicationMvc.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _uow;

        public CartService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Cart? GetCart(string userId)
        {
            return _uow.Cart.GetCartWithItems(userId);
        }

        public int AddItem(string userId, int productId, int quantity)
        {
            _uow.Cart.AddCartItem(userId, productId, quantity);
            return _uow.SaveChanges();
        }

        public int GetItemCount(string userId)
        {
            return _uow.Cart.GetItemCount(userId);
        }

        public decimal GetTotalAmount(string userId)
        {
            return _uow.Cart.GetTotalAmount(userId);
        }

        public int RemoveItem(int cartItemId)
        {
            _uow.Cart.RemoveCartItem(cartItemId);
            return _uow.SaveChanges();
        }

        public int ClearCart(string userId)
        {
            _uow.Cart.ClearCartByUserId(userId);
            return _uow.SaveChanges();
        }
    }
}