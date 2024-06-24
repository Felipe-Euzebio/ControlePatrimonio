using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {       
            CreateMap<CreateDepartmentDTO, Department>();
            
            CreateMap<UpdateDepartmentDTO, Department>();
        }
    }
}