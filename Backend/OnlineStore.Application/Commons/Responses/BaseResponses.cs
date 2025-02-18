namespace OnlineStore.Application.Commons.Responses;
public abstract class BaseResponses<T>
{
    public T Response { get; set; } = default!;
}