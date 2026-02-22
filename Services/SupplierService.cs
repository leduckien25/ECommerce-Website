using AutoMapper;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services.Interfaces;
using WebApplicationMvc.UnitOfWork;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper mapper;

        public SupplierService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            this.mapper = mapper;
        }

        public IEnumerable<SupplierViewModel> GetSuppliersForDisplay() => mapper.Map<IEnumerable<SupplierViewModel>>(_uow.Supplier.GetSuppliersWithProducts());

        public int GetSuppliersCount()
        {
            return _uow.Supplier.GetSuppliersCount();
        }

        public IEnumerable<Supplier> GetSuppliersForAdmin(int page, int pageSize)
        {
            return _uow.Supplier.GetSuppliers(page, pageSize);
        }

        public Supplier? GetSupplierWithProducts(string id)
        {
            return _uow.Supplier.GetSupplierWithProducts(id);
        }

        public bool Update(Supplier supplier)
        {
            _uow.Supplier.Update(supplier);
            return _uow.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            _uow.Supplier.Delete(id);
            return _uow.SaveChanges() > 0;
        }

        public Supplier? Create(Supplier supplier)
        {
            _uow.Supplier.Add(supplier);
            return _uow.SaveChanges() > 0 ? supplier : null;
        }

        public int GetTotalPages(int pageSize)
        {
            return (GetSuppliersCount() - 1) / pageSize + 1;
        }
    }
}
