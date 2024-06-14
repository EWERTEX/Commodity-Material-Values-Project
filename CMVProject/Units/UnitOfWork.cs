using CMVProject.DataBase;
using CMVProject.Repositories;

namespace CMVProject.Units;

public class UnitOfWork : IDisposable
{
    private CMVContext _db;
    private ProductRepository? _productRepository;
    private UserRepository? _userRepository;

    public UnitOfWork(CMVContext context)
    {
        _db = context;
    }

    public ProductRepository Products => _productRepository ??= new ProductRepository(_db);

    public UserRepository Users => _userRepository ??= new UserRepository(_db);

    public void Save()
    {
        _db.SaveChanges();
    }

    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _db.Dispose();
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}