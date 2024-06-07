using AutoMapper;
using Motorcycles.Model;
using Motorcycles.Service.Common.DTOs;

namespace Motorcycles.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Motorcycle, MotorcycleDTO>().ReverseMap();
        }
    }
}