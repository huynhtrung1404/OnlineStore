namespace OnlineStore.Domain.Commons.Interface;
public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
}