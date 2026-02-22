using WebApplicationMvc.Models;
using WebApplicationMvc.Services.Interfaces;
using WebApplicationMvc.UnitOfWork;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Order? Create(string userId, CheckoutViewModel model)
        {
            var cart = _uow.Cart.GetCartWithItems(userId);
            if (cart == null)
            {
                throw new Exception($"Cart not found with userId: {userId}");
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = _uow.Cart.GetTotalAmount(userId) * 1000,
                PaymentMethod = model.PaymentMethod,
                FullName = $"{model.FirstName} {model.LastName}",
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                PostalCode = model.PostalCode,
                PhoneNumber = model.PhoneNumber,
                Note = model.Note,
                OrderDetails = cart.CartItems.Select(ci => new OrderDetail
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            _uow.Order.Create(order);

            int ret = _uow.SaveChanges();

            if (ret > 0) return order;
            return null;
        }

        public Order? GetOrder(int id)
        {
            return _uow.Order.GetOrder(id);
        }

        public IEnumerable<Order>? GetOrders(int page, int pageSize)
        {
            return _uow.Order.GetOrders(page, pageSize);
        }

        public int GetOrdersCount()
        {
            return _uow.Order.GetOrdersCount();
        }

        public IEnumerable<Order> GetRecentOrders()
        {
            return _uow.Order.GetRecentOrders();
        }

        public int GetTotalPages(int pageSize)
        {
            return (GetOrdersCount() - 1) / pageSize + 1;
        }

        public decimal GetTotalRevenue()
        {
            return _uow.Order.GetTotalRevenue();
        }

        public bool UpdateStatus(int orderId, string newStatus)
        {
            var order = _uow.Order.GetOrder(orderId);

            if (order is null) return false;
            order.Status = newStatus;

            return _uow.SaveChanges() > 0;
        }
    }
}
