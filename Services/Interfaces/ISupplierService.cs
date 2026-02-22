using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierViewModel> GetSuppliersForDisplay();
        IEnumerable<Supplier> GetSuppliersForAdmin(int page, int pageSize);
        int GetSuppliersCount();
        Supplier? GetSupplierWithProducts(string id);
        bool Update(Supplier supplier);
        Supplier? Create(Supplier supplier);
        bool Delete(string id);
        int GetTotalPages(int pageSize);
    }
}
