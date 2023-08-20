using OnlineStore.Domain.Commons.Interface;

namespace OnlineStore.Infrastructure.Databases.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{

    private readonly DbContext _context;
    private bool _disposed;
    public UnitOfWork(DbContext context)
    {
        _context = context;
        _disposed = false;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}