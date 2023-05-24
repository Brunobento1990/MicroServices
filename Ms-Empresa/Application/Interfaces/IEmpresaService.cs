using Application.Dtos.EmpresaDtos;

namespace Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<EmpresaViewDto> GetEmpresaById(Guid id);
    }
}
