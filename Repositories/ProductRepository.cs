using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;

namespace WebApplicationMvc.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
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
    public IEnumerable<Product> GetProductsRelation(int id)
    {
        var product = GetProduct(id);
        if (product == null)
            return Enumerable.Empty<Product>();

        return context.Products
                      .Where(p => p.CategoryId == product.CategoryId && p.ProductId != id);
    }
    public IEnumerable<Product> GetProductsByCategory(short id)
        => context.Products.Where(p => p.CategoryId == id);
    public void Add(Product product)
    {
        context.Products.Add(product);
    }
    public void Update(Product product)
    {
        context.Products.Update(product);
    }
    public void Delete(int id)
    {
        var product = context.Products.Find(id);

        if (product != null)
        {
            context.Products.Remove(product);
        }
    }

    public int GetProductsCount()
    {
        return context.Products.Count();
    }
}
