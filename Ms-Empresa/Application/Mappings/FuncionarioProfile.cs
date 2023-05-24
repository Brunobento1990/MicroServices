using Application.Dtos.FuncionarioDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<Funcionario, FuncionarioCreateDto>().ReverseMap();
            CreateMap<Funcionario, FuncionarioViewDto>().ReverseMap();
        }
    }
}
