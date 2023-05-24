using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IGenericRepository<Funcionario> _genericRepository;

        public FuncionarioRepository(IGenericRepository<Funcionario> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> AdicionarFuncionarioAsync(Funcionario funcionario)
        {
            try
            {
                await _genericRepository.AdicionarAsync(funcionario);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
