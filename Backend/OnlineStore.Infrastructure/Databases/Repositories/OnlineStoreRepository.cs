using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Infrastructure.Databases.Contexts;

namespace OnlineStore.Infrastructure.Databases.Repositories;
public class OnlineStoreRepository<T> : GenericRepository<T>, IOnlineStoreRepository<T> where T : BaseEntity<Guid>
{
    public OnlineStoreRepository(OnlineStoreContext context) : base(context)
    {
    }
}