using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected MsContext _dbContext;
        public UnitOfWork(MsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CommitAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
