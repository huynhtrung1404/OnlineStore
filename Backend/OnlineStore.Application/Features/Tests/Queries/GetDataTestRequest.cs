
namespace OnlineStore.Application.Features.Tests.Queries;
public record GetDataTestRequest : IRequest;
public sealed class GetDataTestRequestHandler : IRequestHandler<GetDataTestRequest>
{
    public async Task Handle(GetDataTestRequest request, CancellationToken cancellationToken)
    {
        await Task.FromResult(false);
        throw new NotImplementedException();
    }
}