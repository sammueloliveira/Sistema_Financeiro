using Domain.Entities;
using Domain.Interfaces.InterfaceSistemaFinanceiro;
using Infra.Data;
using Infra.Repositories.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.RepositorySistemaFinanceiro
{
    public class RepositorySistemaFinanceiro : RepositoryGeneric<SistemaFinanceiro>, ISistemaFinanceiro
    {
        private readonly DbContextOptions<Contexto> _dbContextOptions;
        public RepositorySistemaFinanceiro()
        {
            _dbContextOptions = new DbContextOptions<Contexto>();
        }

        public async Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario)
        {
            using (var banco = new Contexto(_dbContextOptions))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario)
                     select s).AsNoTracking().ToListAsync();
            }
        }
    }
}