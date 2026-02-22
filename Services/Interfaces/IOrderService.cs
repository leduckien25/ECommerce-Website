using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services.Interfaces
{
    public interface IOrderService
    {
        Order? Create(string userId, CheckoutViewModel model);
        Order? GetOrder(int id);
        IEnumerable<Order>? GetOrders(int page, int pageSize);
        int GetOrdersCount();
        IEnumerable<Order> GetRecentOrders();
        int GetTotalPages(int pageSize);
        decimal GetTotalRevenue();
        bool UpdateStatus(int orderId, string v);
    }
}
