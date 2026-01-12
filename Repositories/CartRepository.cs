using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Repositories
{
    public class CartRepository : BaseRepository
    {
        public CartRepository(EcommerceDbContext context) : base(context)
        {
        }

        public Cart GetCart(string userId)
        {
            var cart = context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.UserId == userId);

            return cart ?? new Cart { UserId = userId };
        }

        public int AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCart(userId);
            if (cart.CartId == 0)
            {
                context.Carts.Add(cart);
                context.SaveChanges();
            }

            var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new Exception();
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.CartItems.Add(new CartItem { CartId = cart.CartId, ProductId = productId, Quantity = quantity });
            }
            return context.SaveChanges();
        }

        public int GetCartItemCount(string userId)
        {
            var cart = GetCart(userId);
            return cart.CartItems.Count();
        }

        public decimal GetTotalAmount(string userId)
        {
            var cart = GetCart(userId);
            return cart.CartItems.Sum(ci => (ci.Product.Price ?? 0) * ci.Quantity);
        }

        public int Delete(int cartItemId)
        {
            var cartItem = context.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                context.CartItems.Remove(cartItem);
                return context.SaveChanges();
            }
            return -1;
        }

        internal void ClearCart(string userId)
        {
            var cart = GetCart(userId);
            if (cart.CartId != 0)
            {
                context.CartItems.RemoveRange(cart.CartItems);
                context.Carts.Remove(cart);
                context.SaveChanges();
            }
        }
    }
}
