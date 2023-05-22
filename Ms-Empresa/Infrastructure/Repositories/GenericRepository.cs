using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MsContext _dbContext;
        public GenericRepository(MsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AdicionarAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> EditarAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).Property("DataDeCadastro").IsModified = false;
                _dbContext.Entry(entity).Property("DataDeExclusao").IsModified = false;
                _dbContext.Set<T>().Update(entity);

                return (Task<bool>)Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> ExcluirAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).Property("DataDeCadastro").IsModified = false;
                _dbContext.Entry(entity).Property("DataDeAlteracao").IsModified = false;
                _dbContext.Set<T>().Update(entity);

                return (Task<bool>)Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
