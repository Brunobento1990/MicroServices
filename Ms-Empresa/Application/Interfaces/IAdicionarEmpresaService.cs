using Application.Dtos.EmpresaDtos;

namespace Application.Interfaces
{
    public interface IAdicionarEmpresaService
    {
        Task<EmpresaViewDto> AdicionarEmpresaAsync(EmpresaCreateDto empresaCreateDto);
    }
}
