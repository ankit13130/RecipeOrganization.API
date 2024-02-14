using AutoMapper;
using RecipeOrganization.Core.Domain.RequestModels;
using RecipeOrganization.Core.Domain.ResponseModels;
using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.API.Configurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponseModel>().ReverseMap();
        CreateMap<User, UserRequestModel>().ReverseMap();
    }
}
