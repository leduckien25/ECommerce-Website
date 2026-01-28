using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;
using WebApplicationMvc.Repositories.Interfaces;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Repositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(EcommerceDbContext context) : base(context)
        {
        }
        public IEnumerable<Supplier> GetSuppliers() => context.Suppliers;
        public IEnumerable<Supplier> GetSuppliers(out int pages, int page, int size = 12)
        {
            pages = (context.Suppliers.Count() - 1) / size + 1;
            return context.Suppliers.Skip((page - 1) * size).Take(size);
        }

        public Supplier? GetSupplier(string id) => context.Suppliers.SingleOrDefault(s => s.SupplierId == id);
        public void Add(Supplier Supplier)
        {
            var names = Supplier.SupplierName.Split(' ').ToList();

            string id = string.Concat(names.Select(name => char.ToUpper(name[0])));

            Supplier.SupplierId = id;

            context.Suppliers.Add(Supplier);
        }
        public void Update(Supplier Supplier)
        {
            context.Suppliers.Update(Supplier);
        }
        public void Delete(string id)
        {
            var Supplier = context.Suppliers.Find(id);
            if (Supplier != null)
            {
                context.Suppliers.Remove(Supplier);
            }
        }

        public int GetSuppliersCount()
        {
            return context.Suppliers.Count();
        }

        public Supplier? GetSupplierWithProducts(string id)
        {
            return context.Suppliers.Where(s => s.SupplierId == id).Include(s => s.Products).ThenInclude(p => p.Category).SingleOrDefault();
        }
    }
}
