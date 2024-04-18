using OnlineStore.Application.Commons.Responses;

namespace OnlineStore.Application.Responses;
public class ItemResponse<T> : BaseResponses<T>
{
    public ItemResponse(T response)
    {
        Response = response;
    }
    public ItemResponse()
    {

    }
}