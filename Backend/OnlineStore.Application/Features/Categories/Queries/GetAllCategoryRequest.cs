
using AutoMapper;
using OnlineStore.Application.Responses;
using OnlineStore.Application.Specifications;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Categories.Queries;
public record GetAllCategoryRequest(long PageSize, long PageNumber) : IRequest<ListResponse<CategoryDto>> { }

public sealed class GetAllCategoryRequestHandler : IRequestHandler<GetAllCategoryRequest, ListResponse<CategoryDto>>
{
    private readonly IOnlineStoreRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoryRequestHandler(IOnlineStoreRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ListResponse<CategoryDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
    {
        var specification = new CategorySpecification(request.PageSize, request.PageNumber);
        var result = await _categoryRepository.GetListAsync(specification);
        return new()
        {
            Response = _mapper.Map<IEnumerable<CategoryDto>>(result),
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
            TotalCount = await _categoryRepository.CountAsync(new CategorySpecification())
        };
    }
}