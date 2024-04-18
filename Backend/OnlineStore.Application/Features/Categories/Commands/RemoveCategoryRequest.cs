
using OnlineStore.Application.Responses;
using OnlineStore.Application.Specifications;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Categories.Commands;
public class RemoveCategoryRequest : IRequest<ItemResponse<bool>>
{
    internal Guid Id { get; init; }

    public RemoveCategoryRequest(Guid id)
    {
        Id = id;
    }
}

public class RemoveCategoryRequestHandler : IRequestHandler<RemoveCategoryRequest, ItemResponse<bool>>
{
    private readonly IOnlineStoreRepository<Category> _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCategoryRequestHandler(IOnlineStoreRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse<bool>> Handle(RemoveCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _categoryRepository.GetItemAsync(new CategorySpecification(request.Id));
        if (item is null)
        {
            throw new Exception("Not found the data");
        }
        _categoryRepository.Remove(item);
        await _unitOfWork.CommitChangesAsync();
        return new(true);
    }
}