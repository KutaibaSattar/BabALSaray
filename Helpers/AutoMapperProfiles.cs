using BabALSaray.AppEntities;
using AutoMapper;
using BabALSaray.DTOs;
using DTOs;

namespace BabALSaray.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          CreateMap<dbAccounts,dbAccountsDto>();
          CreateMap<AppUser,UserDto>();
          CreateMap<AppUser,MemberDto>();
          CreateMap<Product,ProductToReturnDto>();
          CreateMap<RegisterDto,AppUser>();
          CreateMap<Address,AddressDto>().ReverseMap();
          CreateMap<CustomerBasketDto, CustomerBasket>();
          CreateMap<BasketItemDto, BasketItem>();
         
          CreateMap<Product,ProductToReturnDto>()
            .ForMember(d => d.ProductBrand, opt => opt.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, opt => opt.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());
          
        }
    }
}