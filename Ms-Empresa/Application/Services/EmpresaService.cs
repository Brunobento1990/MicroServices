using Application.Dtos.EmpresaDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<EmpresaViewDto> GetEmpresaById(Guid id)
        {
            try
            {
                var empresa = await _empresaRepository.GetEmpresaAsync(id);

                if (empresa == null)
                    throw new Exception($"Não foi possível localizar a empresa em nossa base de dados.");

                return _mapper.Map<EmpresaViewDto>(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
