using Domain.Entities;
using Domain.Interfaces.InterfaceCategoria;
using Infra.Data;
using Infra.Repositories.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.RepositoryCategoria
{
    public class RepositoryCategoria : RepositoryGeneric<Categoria>, ICategoria
    {
        private readonly DbContextOptions<Contexto> _dbContextOptions;
        public RepositoryCategoria()
        {
            _dbContextOptions = new DbContextOptions<Contexto>();
        }

        public async Task<IList<Categoria>> ListarCategoriaUsuario(string emailUsuario)
        {
            using (var banco = new Contexto(_dbContextOptions))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join c in banco.Categoria on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}