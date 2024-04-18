
using AutoMapper;
using OnlineStore.Application.Responses;
using OnlineStore.Application.Specifications;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Categories.Queries;
public class GetCategoryByIdRequest : IRequest<ItemResponse<CategoryDto>>
{
    internal Guid Id { get; init; }
    public GetCategoryByIdRequest(Guid id)
    {
        Id = id;
    }
}

public class GetCategoryByIdRequestHandler : IRequestHandler<GetCategoryByIdRequest, ItemResponse<CategoryDto>>
{
    private readonly IOnlineStoreRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdRequestHandler(IOnlineStoreRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ItemResponse<CategoryDto>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var data = await _categoryRepository.GetListAsync(new CategorySpecification(request.Id));
        return new()
        {
            Response = _mapper.Map<CategoryDto>(data)
        };
    }
}