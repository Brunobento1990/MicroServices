using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IGenericRepository<Empresa> _genericRepository;
        protected MsContext _dbContext;

        public EmpresaRepository(IGenericRepository<Empresa> genericRepository,
            MsContext dbContext)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> AdicionarEmpresaAsync(Empresa empresa)
        {
            try
            {
                await _genericRepository.AdicionarAsync(empresa);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Empresa> GetEmpresaAsync(Guid id)
        {
            try
            {
                return await _dbContext.Empresas
                    .AsNoTracking()
                    .Include(x => x.EnderecoEmpresa)
                    .Include(x => x.ContatosEmpresa.Where(x => x.DataDeExclusao == null))
                    .FirstOrDefaultAsync(x => x.Id == id && x.DataDeExclusao == null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ValidarCnpjCadastradoAsync(string cnpj)
        {
            try
            {
                var empresa = await _dbContext.Empresas
                    .AsNoTracking()
                    .Include(x => x.EnderecoEmpresa)
                    .Include(x => x.ContatosEmpresa)
                    .FirstOrDefaultAsync(x => x.Cnpj == cnpj);

                return empresa == null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
