using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<bool> AdicionarEmpresaAsync(Empresa empresa);
        Task<bool> ValidarCnpjCadastradoAsync(string cnpj);
        Task<Empresa> GetEmpresaAsync(Guid id);
    }
}
