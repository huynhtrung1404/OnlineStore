namespace OnlineStore.Web.ViewModels;
public class ResponseListViewModel<T>
{
    public long PageSize { get; set; }
    public long PageNumber { get; set; }
    public long TotalCount { get; set; }
    public IEnumerable<T> Response { get; set; } = new List<T>();
}

public class ResponseItemViewModel<T>
{
    public T Response { get; set; } = default!;
}