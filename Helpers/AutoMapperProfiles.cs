using BabALSaray.AppEntities;
using AutoMapper;
using BabALSaray.DTOs;
using DTOs;
using BabALSaray.AppEntities.OrderAggregate;
using Helpers;
using BabALSaray.AppEntities.Project;
using System;
using BabALSaray.Queries.Project;

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
          CreateMap<RegisterDto,AppUser>();
          CreateMap<Address,AddressDto>().ReverseMap();
          CreateMap<AddressDto,OrderAddress>().ReverseMap();
          CreateMap<CustomerBasketDto, CustomerBasket>();
          CreateMap<BasketItemDto, BasketItem>();
          CreateMap<ProjectQueryDto,ProjectQuery>();
          
         
          CreateMap<Product,ProductDto>()
            .ForMember(d => d.ProductBrand, opt => opt.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, opt => opt.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());

            CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.OrderMethod, o => o.MapFrom( s => s.OrderMethod.ShortName))
            .ForMember(d => d.OrderMethodPrice, o => o.MapFrom( s => s.OrderMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
            .ForMember( d => d.ProductId, o => o.MapFrom( s => s.ItemOrdered.ProductItemId))
            .ForMember( d => d.ProductName, o => o.MapFrom( s => s.ItemOrdered.ProductName))
            .ForMember( d => d.PictureUrl, o => o.MapFrom( s => s.ItemOrdered.pictureUrl))
            .ForMember( d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());

            CreateMap<Project,ProjectDto>().ReverseMap();

          
        }
    }
}