
using AutoMapper;
using OnlineStore.Application.Responses;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Categories.Commands;
public class UpdateCategoryRequest : IRequest<ItemResponse<bool>>
{
    internal CategoryDto Category { get; init; }

    public UpdateCategoryRequest(CategoryDto category)
    {
        Category = category;
    }
}

public class UpdateCategoryRequestHandler : IRequestHandler<UpdateCategoryRequest, ItemResponse<bool>>
{
    private readonly IOnlineStoreRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryRequestHandler(IOnlineStoreRepository<Category> categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse<bool>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Category>(request.Category);
        _categoryRepository.Update(data);
        await _unitOfWork.CommitChangesAsync();
        return new(true);
    }
}