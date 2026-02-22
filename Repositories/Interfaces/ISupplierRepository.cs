using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliersWithProducts();
        IEnumerable<Supplier> GetSuppliers(int page, int size = 12);
        Supplier? GetSupplier(string id);
        Supplier? GetSupplierWithProducts(string id);
        int GetSuppliersCount();
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(string id);
    }
}
