using Application.Dtos.EmpresaDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaCreateDto>().ReverseMap();
            CreateMap<Empresa, EmpresaViewDto>().ReverseMap();
        }
    }
}
