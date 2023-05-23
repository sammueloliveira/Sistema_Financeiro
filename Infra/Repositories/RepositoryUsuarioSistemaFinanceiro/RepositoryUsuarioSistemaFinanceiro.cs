using Domain.Entities;
using Domain.Interfaces.InterfaceUsuarioSistemaFinanceiro;
using Infra.Data;
using Infra.Repositories.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.RepositoryUsuarioSistemaFinanceiro
{
    public class RepositoryUsuarioSistemaFinanceiro : RepositoryGeneric<UsuarioSistemaFinanceiro>, IUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<Contexto> _dbContextOptions;
        public RepositoryUsuarioSistemaFinanceiro()
        {
            _dbContextOptions = new DbContextOptions<Contexto>();
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema)
        {
            using (var banco = new Contexto(_dbContextOptions))
            {
                return await
                     banco.UsuarioSistemaFinanceiro
                     .Where(s => s.IdSistema == IdSistema).AsNoTracking()
                     .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new Contexto(_dbContextOptions))
            {
                return await
                     banco.UsuarioSistemaFinanceiro
                     .AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new Contexto(_dbContextOptions))
            {
                banco.UsuarioSistemaFinanceiro
                .RemoveRange(usuarios);

                await banco.SaveChangesAsync();

            }
        }
    }
}