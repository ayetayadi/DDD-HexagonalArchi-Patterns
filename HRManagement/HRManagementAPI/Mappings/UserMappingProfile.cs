using AutoMapper;
using HRManagement.API.DTOs.UserDTO;
using HRManagement.Domain.AggregateModels.UserAggregate;

namespace HRManagement.API.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            CreateMap<IEnumerable<User>, GetUserListResponse>()
                     .ConvertUsing((src, dest, context) => new GetUserListResponse
                     {
                         Users = src.Select(user => context.Mapper.Map<UserDto>(user)).ToList()
                     });


            CreateMap<GetUserByIdRequest, User>();

            CreateMap<User, GetUserByIdResponse>();

            CreateMap<AddUserRequest, User>();

            CreateMap<User, AddUserResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdateUserRequest, User>();

            CreateMap<User, UpdateUserResponse>();
        }
    }
}
