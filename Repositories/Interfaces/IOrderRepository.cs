using WebApplicationMvc.Models;

namespace WebApplicationMvc.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrders(out int totalPages, int page, int size = 12);
        IEnumerable<Order> GetRecentOrders(int size = 10);

        int GetOrdersCount();

        Order? GetOrder(int orderId);
        IEnumerable<Order> GetOrders(string userId);

        void Create(Order order);
        bool UpdateStatus(int orderId, string status);

        decimal GetTotalRevenue();

        bool DeleteOrderDetail(int orderDetailId);
        OrderDetail? GetOrderDetail(int orderDetailId);
    }
}
