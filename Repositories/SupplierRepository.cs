using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Linq;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Repositories
{
    public class SupplierRepository : BaseRepository
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

        public Supplier GetSupplier(short id) => context.Suppliers.Find(id);
        public IEnumerable<SupplierViewModel> GetSupplierViewModels()
                => context.Suppliers
                .Include(c => c.Products)
                .Select(c => new SupplierViewModel
                {
                    SupplierId = c.SupplierId,
                    SupplierName = c.SupplierName,
                    ProductCount = c.Products.Count()
                }).ToList();

        public int Add(Supplier Supplier)
        {
            var names = Supplier.SupplierName.Split(' ').ToList();

            string id = string.Concat(names.Select(name => char.ToUpper(name[0])));

            Supplier.SupplierId = id;

            context.Suppliers.Add(Supplier);
            return context.SaveChanges();
        }
        public int Update(Supplier Supplier)
        {
            context.Suppliers.Update(Supplier);
            return context.SaveChanges();
        }
        public int Delete(string id)
        {
            var Supplier = context.Suppliers.Find(id);
            if (Supplier != null)
            {
                context.Suppliers.Remove(Supplier);
                return context.SaveChanges();
            }
            return -1;
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
