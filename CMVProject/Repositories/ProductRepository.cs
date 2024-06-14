using CMVProject.DataBase;
using CMVProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CMVProject.Repositories;

public class ProductRepository : IRepository<Product>
{
    private readonly CMVContext _db;

    public ProductRepository(CMVContext context)
    {
        _db = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _db.Products.Include(x => x.Storekeeper);
    }

    public Product? Get(int id)
    {
        return _db.Products.Find(id);
    }

    public Product Create(Product product)
    {
        _db.Products.Add(product);
        return product;
    }

    public Product? Update(Product product)
    {
        var updatingProduct = _db.Products.FirstOrDefault(p => p.Id == product.Id);

        if (updatingProduct == null)
            return updatingProduct;
        
        updatingProduct.Name = product.Name;
        updatingProduct.Provider = product.Provider;
        updatingProduct.Storekeeper = product.Storekeeper;
        updatingProduct.DeliveryDate = product.DeliveryDate;
        updatingProduct.AccountingDate = product.AccountingDate;

        return product;
    }

    public Product? Delete(int id)
    {
        var product = _db.Products.Find(id);

        if (product != null)
            _db.Products.Remove(product);
        return product;
    }
}