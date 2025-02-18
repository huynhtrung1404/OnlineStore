using OnlineStore.Application.Commons.Responses;

namespace OnlineStore.Application.Responses;
public class ListResponse<T> : BaseResponses<IEnumerable<T>>
{
    public long TotalCount { get; set; }
    public long PageSize { get; set; }
    public long PageNumber { get; set; }
}