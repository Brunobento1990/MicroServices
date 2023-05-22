using Application.Dtos.ContatosEmpresaDtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class ContatosEmpresaProfile : Profile
    {
        public ContatosEmpresaProfile()
        {
            CreateMap<ContatoEmpresa, ContatosEmpresaCreateDto>().ReverseMap();
            CreateMap<ContatoEmpresa, ContatosEmpresaViewDto>().ReverseMap();
        }
    }
}
