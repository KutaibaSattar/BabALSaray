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
          CreateMap<Product,ProductDto>();
         
          CreateMap<Product,ProductToReturnDto>()
            .ForMember(d => d.ProductBrand, op => op.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, op => op.MapFrom(s => s.ProductType.Name));
          
        }
    }
}