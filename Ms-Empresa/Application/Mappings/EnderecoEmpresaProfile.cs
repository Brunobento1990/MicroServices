using Application.Dtos.EnderecoEmpresaDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class EnderecoEmpresaProfile : Profile
    {
        public EnderecoEmpresaProfile()
        {
            CreateMap<EnderecoEmpresa, EnderecoEmpresaCreateDto>().ReverseMap();
            CreateMap<EnderecoEmpresa, EnderecoEmpresaViewDto>().ReverseMap();
        }
    }
}
