using CMVProject.Models;
using CMVProject.Units;

namespace CMVProject.Controllers;

public class ProductController
{
    private readonly UnitOfWork _unitOfWork;

    public ProductController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _unitOfWork.Products.GetAll();
    }

    public Product? GetProductById(int id) 
    {
        return _unitOfWork.Products.Get(id);
    }

    public void EditProduct(Product product)
    {
        _unitOfWork.Products.Update(product);
        _unitOfWork.Save();
    }

    public void AddProduct(Product product)
    {
        _unitOfWork.Products.Create(product);
        _unitOfWork.Save();
    }

    public void DeleteProduct(int id)
    {
        _unitOfWork.Products.Delete(id);
        _unitOfWork.Save();
    }
}