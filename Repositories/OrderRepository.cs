using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Repositories
{
    public class OrderRepository : BaseRepository
    {
        public OrderRepository(EcommerceDbContext context) : base(context)
        {
        }

        public List<Order> GetOrders()
        {
            return context.Orders.ToList();
        }
        public List<Order> GetOrders(out int totalPages, int page, int size = 12)
        {
            totalPages = (context.Orders.Count() - 1) / size + 1;
            return context.Orders.Skip(size * (page - 1)).Take(size).ToList();
        }
        public List<Order> GetRecentOrders(int size = 10)
        {
            return context.Orders.OrderByDescending(o => o.OrderDate).Take(size).ToList();
        }
        public int GetOrdersCount()
        {
            return context.Orders.Count();
        }
        public Order? GetOrderById(int orderId)
        {
            return context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.OrderId == orderId);
        }
        public Order? GetOrderByUserId(string userId)
        {
            return context.Orders.FirstOrDefault(o => o.UserId == userId);
        }

        public int CreateOrder(Order order)
        {
            context.Orders.Add(order);
            return context.SaveChanges();
        }

        public int UpdateOrder(int id, string status)
        {
            var order = GetOrderById(id);

            if (order == null)
            {
                return -1;
            }
            order.Status = status;
            return context.SaveChanges();
        }

        public decimal GetTotalRevenue()
        {
            return context.Orders.Sum(o => o.TotalAmount);
        }

        public int DeleteItem(int id)
        {
            var orderDetails = context.OrderDetails.SingleOrDefault(od => od.OrderId == id);
            if (orderDetails == null)
            {
                return -1;
            }

            context.OrderDetails.Remove(orderDetails);
            return context.SaveChanges();
        }

        internal OrderDetail? GetOrderDetailById(int orderDetailId)
        {
            return context.OrderDetails.FirstOrDefault(od => od.OrderDetailId == orderDetailId);
        }


    }
}
