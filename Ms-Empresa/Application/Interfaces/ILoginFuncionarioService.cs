using Application.Dtos.FuncionarioDtos;

namespace Application.Interfaces
{
    public interface ILoginFuncionarioService
    {
        Task<string> LoginAsync(FuncionarioLoginDto funcionarioLoginDto);
    }
}
