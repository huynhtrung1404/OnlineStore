using System.Data;
using System.Data.Common;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Infrastructure.Databases.Contexts;

namespace OnlineStore.Infrastructure.Databases.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{

    #region Fields
    private bool _disposed;
    private readonly DbContext _dbContext;
    #endregion

    public UnitOfWork(OnlineStoreContext dbContext)
    {
        _dbContext = dbContext;
    }


    #region Private methods
    private DbConnection DbConnection => _dbContext.Database.GetDbConnection(); //https://stackoverflow.com/questions/41935752/entity-framework-core-how-to-get-the-connection-from-the-dbcontext

    private DbTransaction DbTransaction { get; set; } = null!;
    private void OpenConnection()
    {
        if (DbConnection.State != ConnectionState.Open)
        {
            DbConnection.Open();
        }
    }

    /// <summary>
    /// Releases the current transaction
    /// </summary>
    private static void ReleaseTransaction(IDisposable transaction)
    {
        transaction?.Dispose();
    }

    #endregion

    #region Methods

    public virtual IDisposable BeginTransaction(IsolationLevel level)
    {
        var transaction = DbTransaction;
        if (transaction != null)
        {
            throw new Exception("Cannot begin a new transaction while an existing transaction is still running. " +
                                            "Please commit or rollback the existing transaction before starting a new one.");
        }

        OpenConnection();
        transaction = DbConnection.BeginTransaction(level);
        _dbContext.Database.UseTransaction(transaction);
        DbTransaction = transaction;
        return transaction;
    }

    public virtual void CommitTransaction()
    {
        var transaction = DbTransaction;
        if (transaction == null)
        {
            throw new ArgumentException("Cannot roll back a transaction while there is no transaction running.");
        }

        try
        {
            _dbContext.SaveChanges();
            transaction.Commit();
            ReleaseTransaction(transaction);
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
    }

    public virtual void RollbackTransaction()
    {
        var transaction = DbTransaction;
        if (transaction == null)
        {
            throw new ArgumentException("Cannot roll back a transaction while there is no transaction running.");
        }

        transaction.Rollback();
        ReleaseTransaction(transaction);
    }

    public virtual void CommitChanges()
    {
        try
        {
            _dbContext.SaveChanges();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            var entry = exception.Entries[0];
            if (entry != null)
            {
                throw new DbUpdateConcurrencyException("Cannot commit");
            }
        }
    }

    public virtual async Task CommitChangesAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            var entry = exception.Entries[0];
            if (entry != null)
            {

                throw new DbUpdateConcurrencyException("Cannot commit");
            }
        }

    }

    #endregion

    #region Implementation of IDisposable

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes off the managed and unmanaged resources used.
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _dbContext.Dispose();
        }

        _disposed = true;
    }

    #endregion
}