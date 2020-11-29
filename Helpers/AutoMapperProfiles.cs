using AppEntities;
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
          
        }
    }
}