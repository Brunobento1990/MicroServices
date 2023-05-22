using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<bool> AdicionarFuncionarioAsync(Funcionario funcionario);
    }
}
