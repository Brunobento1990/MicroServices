using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGerarTokenSerive
    {
        string GetToken(Funcionario funcionario);
    }
}
