using AutoMapper;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Commons.Mappings;
public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Customer, AccountDto>().ReverseMap();
        CreateMap<Account, AccountDto>().ReverseMap();
    }
}