using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers();
        IEnumerable<Supplier> GetSuppliers(out int pages, int page, int size = 12);
        Supplier? GetSupplier(string id);
        Supplier? GetSupplierWithProducts(string id);
        int GetSuppliersCount();
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(string id);
    }
}
