using AutoMapper;
using HRManagement.API.DTOs.DepartmentDTO;
using HRManagement.Domain.AggregateModels.DepartmentAggregate;
using HRManagement.Domain.AggregateModels.UserAggregate;

namespace HRManagement.API.Mappings
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Id));

            CreateMap<IEnumerable<Department>, GetDepartmentsResponse>()
                .ConvertUsing((src, dest, context) => new GetDepartmentsResponse
                {
                    Departments = src.Select(department => context.Mapper.Map<DepartmentDto>(department)).ToList()
                });

            CreateMap<GetDepartmentByIdRequest, Department>();

            CreateMap<Department, GetDepartmentByIdResponse>();

            CreateMap<AddDepartmentRequest, Department>();

            CreateMap<Department, AddDepartmentResponse>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdateDepartmentRequest, Department>();

            CreateMap<Department, UpdateDepartmentResponse>();
        }
    }
}
