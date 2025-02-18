namespace OnlineStore.Domain.Commons.Interface;
public interface IOnlineStoreRepository<T> : IGenericRepository<T> where T : BaseEntity<Guid>
{

}