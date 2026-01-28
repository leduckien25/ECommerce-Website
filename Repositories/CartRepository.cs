using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Repositories
{
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(EcommerceDbContext context) : base(context)
        {
        }

        public Cart? GetCart(string userId)
        {
            return context.Carts
                          .Include(c => c.CartItems)
                          .ThenInclude(ci => ci.Product)
                          .SingleOrDefault(c => c.UserId == userId);
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = context.Carts
                                  .Include(c => c.CartItems)
                                  .SingleOrDefault(c => c.UserId == userId);
            if (cart is null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };
                context.Carts.Add(cart);
            }

            var product = context.Products.SingleOrDefault(p => p.ProductId == productId);

            if (product == null)
                throw new Exception($"Not found product with this id: {productId}");

            var cartItem = cart.CartItems.SingleOrDefault(ci => ci.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
        }

        public int GetCartItemCount(string userId)
        {
            return context.CartItems
                  .Count(ci => ci.Cart.UserId == userId);
        }

        public decimal GetTotalAmount(string userId)
        {
            return context.CartItems
                .Where(ci => ci.Cart.UserId == userId)
                .Sum(ci => (ci.Product.Price ?? 0) * ci.Quantity);
        }

        public void Delete(int cartItemId)
        {
            var cartItem = context.CartItems.SingleOrDefault(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                context.CartItems.Remove(cartItem);
            }
        }

        public void ClearCart(string userId)
        {
            var cart = context.Carts
                      .Include(c => c.CartItems)
                      .SingleOrDefault(c => c.UserId == userId);

            if (cart == null)
                return;

            context.CartItems.RemoveRange(cart.CartItems);
            context.Carts.Remove(cart);
        }
    }
}
