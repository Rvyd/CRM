using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace CRMApp.Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyDtoForInsertion,Company>();
            CreateMap<CompanyDtoForUpdate,Company>().ReverseMap();
            CreateMap<UserDtoForCreation,IdentityUser>();
            CreateMap<UserDtoForUpdate,IdentityUser>().ReverseMap();
           CreateMap<TalkDtoForInsertion, Talk>();
            CreateMap<TalkDtoForUpdate,Talk>().ReverseMap();
            
        }
    }
}