using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;
using WebApplicationMvc.ViewModels;

namespace WebApplicationMvc.Repositories;

public class ProductRepository : BaseRepository
{
    public ProductRepository(EcommerceDbContext context) : base(context)
    {
    }
    public IEnumerable<Product> GetProducts() => context.Products;

    public IEnumerable<Product> GetProductsWithDetails()
    {
        return context.Products.Include(p => p.Category)
                      .Include(p => p.Supplier);
    }
    public IEnumerable<Product> GetProductsWithDetails(out int pages, int page, int size = 12)
    {
        pages = (context.Products.Count() - 1) / size + 1;
        return context.Products.Include(p => p.Category)
                      .Include(p => p.Supplier)
                      .Skip((page - 1) * size).Take(size);
    }
    public Product? GetProduct(int id) => context.Products.Find(id);
    public Product? GetProductWithDetails(int id)
    {
        return context.Products
                      .Include(p => p.Category)
                      .Include(p => p.Supplier)
                      .FirstOrDefault(p => p.ProductId == id);
    }
    public ProductViewModel? GetProductViewModel(int id)
    {
        var product = context.Products
                             .Include(p => p.Category)
                             .FirstOrDefault(p => p.ProductId == id);

        if (product == null) return null;
        return new ProductViewModel
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            CategoryId = product.CategoryId,
            CategoryName = product.Category.CategoryName,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            Description = product.Description
        };
    }
    public IQueryable<Product>? GetProductsRelation(int id)
    {
        var product = GetProduct(id);
        if (product == null) return null;

        return context.Products
                      .Where(p => p.CategoryId == product.CategoryId && p.ProductId != id);
    }
    public IEnumerable<ProductViewModel>? GetProductViewModelsRelation(int id)
    {
        var products = GetProductsRelation(id);
        if (products == null) return Enumerable.Empty<ProductViewModel>();

        return products.Include(p => p.Category)
                       .Select(p => new ProductViewModel
                       {
                           ProductId = p.ProductId,
                           ProductName = p.ProductName,
                           CategoryName = p.Category.CategoryName,
                           ImageUrl = p.ImageUrl,
                           Price = p.Price,
                           Description = p.Description
                       });
    }
    public IEnumerable<ProductViewModel>? GetProductViewModelsRelation(int id, int pageSize, int page, out int pages)
    {
        var products = GetProductsRelation(id);
        if (products == null)
        {
            pages = 0;
            return Enumerable.Empty<ProductViewModel>();
        }

        pages = (products.Count() - 1) / pageSize + 1;

        return products.Include(p => p.Category)
                       .Select(p => new ProductViewModel
                       {
                           ProductId = p.ProductId,
                           ProductName = p.ProductName,
                           CategoryName = p.Category.CategoryName,
                           ImageUrl = p.ImageUrl,
                           Price = p.Price,
                           Description = p.Description
                       }).Skip((page - 1) * pageSize).Take(pageSize);
    }
    public IEnumerable<ProductViewModel> GetProductViewModels(int pageSize, int page, out int pages)
    {
        var productViewModels = context.Products
        .Include(p => p.Category)
        .Select(p => new ProductViewModel
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            CategoryName = p.Category.CategoryName,
            ImageUrl = p.ImageUrl,
            Price = p.Price,
            Description = p.Description
        }).ToList();

        pages = (productViewModels.Count() - 1) / pageSize + 1;
        return productViewModels.Skip((page - 1) * pageSize).Take(pageSize);
    }
    public IEnumerable<Product> GetProductsByCategory(short id)
        => context.Products.Where(p => p.CategoryId == id).ToList();
    public IEnumerable<ProductViewModel> GetProductViewModelsByCategory(short id)
        => context.Products.Where(p => p.CategoryId == id).Select(p => new ProductViewModel
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            CategoryName = p.Category.CategoryName,
            ImageUrl = p.ImageUrl,
            Price = p.Price,
            Description = p.Description
        });
    public IEnumerable<ProductViewModel> GetProductViewModelsByCategory(short id, int pageSize, int page, out int pages)
    {
        var productViewModels = context.Products.Where(p => p.CategoryId == id).Select(p => new ProductViewModel
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            CategoryName = p.Category.CategoryName,
            ImageUrl = p.ImageUrl,
            Price = p.Price,
            Description = p.Description
        });
        pages = (productViewModels.Count() - 1) / pageSize + 1;
        return productViewModels.Skip((page - 1) * pageSize).Take(pageSize);
    }
    public IEnumerable<ProductViewModel> GetProductViewModelsBySupplier(string id)
      => context.Products.Where(p => p.SupplierId == id).Select(p => new ProductViewModel
      {
          ProductId = p.ProductId,
          ProductName = p.ProductName,
          CategoryName = p.Category.CategoryName,
          ImageUrl = p.ImageUrl,
          Price = p.Price,
          Description = p.Description
      });
    public IEnumerable<ProductViewModel> GetProductViewModelsBySupplier(string id, int pageSize, int page, out int pages)
    {
        var productViewModels = context.Products.Where(p => p.SupplierId == id).Select(p => new ProductViewModel
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            CategoryName = p.Category.CategoryName,
            ImageUrl = p.ImageUrl,
            Price = p.Price,
            Description = p.Description
        });
        pages = (productViewModels.Count() - 1) / pageSize + 1;
        return productViewModels.Skip((page - 1) * pageSize).Take(pageSize);
    }
    public int Add(Product product)
    {
        context.Products.Add(product);
        return context.SaveChanges();
    }
    public int Update(Product product)
    {
        context.Products.Update(product);
        return context.SaveChanges();
    }
    public int Delete(int id)
    {
        var product = context.Products.Find(id);

        if (product != null)
        {
            Helper.DeleteImage(product);
            context.Products.Remove(product);
            return context.SaveChanges();
        }
        return -1;
    }

    public int GetProductsCount()
    {
        return context.Products.Count();
    }

    public int UpdateProduct(Product product)
    {
        context.Products.Update(product);
        return context.SaveChanges();
    }
}
