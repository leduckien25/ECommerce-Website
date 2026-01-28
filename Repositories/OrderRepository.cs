using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;
using WebApplicationMvc.Repositories.Interfaces;

namespace WebApplicationMvc.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(EcommerceDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.ToList();
        }
        public IEnumerable<Order> GetOrders(out int totalPages, int page, int size = 12)
        {
            totalPages = (context.Orders.Count() - 1) / size + 1;
            return context.Orders.Skip(size * (page - 1)).Take(size).ToList();
        }
        public IEnumerable<Order> GetRecentOrders(int size = 10)
        {
            return context.Orders.OrderByDescending(o => o.OrderDate).Take(size).ToList();
        }
        public int GetOrdersCount()
        {
            return context.Orders.Count();
        }
        public Order? GetOrder(int orderId)
        {
            return context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.OrderId == orderId);
        }
        public IEnumerable<Order> GetOrders(string userId)
        {
            return context.Orders.Where(o => o.UserId == userId);
        }

        public void Create(Order order)
        {
            context.Orders.Add(order);
        }

        public bool UpdateStatus(int id, string status)
        {
            var order = GetOrder(id);

            if (order == null)
            {
                return false;
            }
            order.Status = status;
            return true;
        }

        public decimal GetTotalRevenue()
        {
            return context.Orders.Sum(o => o.TotalAmount);
        }

        public bool DeleteOrderDetail(int id)
        {
            var orderDetails = context.OrderDetails.SingleOrDefault(od => od.OrderDetailId == id);
            if (orderDetails == null)
            {
                return false;
            }

            context.OrderDetails.Remove(orderDetails);
            return true;
        }

        public OrderDetail? GetOrderDetail(int orderDetailId)
        {
            return context.OrderDetails.FirstOrDefault(od => od.OrderDetailId == orderDetailId);
        }


    }
}
