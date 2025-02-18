using AutoMapper;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Entity;
using OnlineStore.Shared.Common.Utilities;

namespace OnlineStore.Application.Commons.Mappings;
public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Customer, AccountDto>().ReverseMap();
        CreateMap<Account, AccountDto>().ReverseMap()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Utilities.EncryptSHA512(src.Password)));
        CreateMap<UserToken, UserInfoDto>().ReverseMap();
        CreateMap<Customer, UserDto>().ReverseMap();
    }
}