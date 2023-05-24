using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        protected MsContext _dbContext;

        public LoginRepository(MsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Funcionario> LoginAsync(string email)
        {
            try
            {
                return await _dbContext.Funcionarios
                    .AsNoTracking()
                    .Include(x => x.Empresa)
                    .FirstOrDefaultAsync(x => x.Email == email &&
                     x.DataDeExclusao == null &&
                     x.EmailVerificado == true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
