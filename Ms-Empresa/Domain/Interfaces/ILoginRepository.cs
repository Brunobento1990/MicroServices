using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task<Funcionario> LoginAsync(string email);
    }
}
