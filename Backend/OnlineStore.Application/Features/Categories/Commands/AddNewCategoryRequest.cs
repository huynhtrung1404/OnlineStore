
using AutoMapper;
using OnlineStore.Application.Responses;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Categories.Commands;
public class AddNewCategoryRequest : IRequest<ItemResponse<bool>>
{
    internal CategoryDto Category { get; init; }

    public AddNewCategoryRequest(CategoryDto category)
    {
        Category = category;
    }
}

public class AddNewCategoryRequestHandler : IRequestHandler<AddNewCategoryRequest, ItemResponse<bool>>
{
    private readonly IOnlineStoreRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddNewCategoryRequestHandler(IOnlineStoreRepository<Category> categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse<bool>> Handle(AddNewCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request.Category);
        await _categoryRepository.InsertAsync(category);
        await _unitOfWork.CommitChangesAsync();
        return new(true);
    }
}