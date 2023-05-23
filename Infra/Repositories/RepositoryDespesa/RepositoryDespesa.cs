﻿using Domain.Entities;
using Domain.Interfaces.InterfaceDespesa;
using Infra.Data;
using Infra.Repositories.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.RepositoryDespesa
{
    public class RepositoryDespesa : RepositoryGeneric<Despesa>, IDespesa
    {
        private readonly DbContextOptions<Contexto> _dbContextOptions;
        public RepositoryDespesa()
        {
            _dbContextOptions = new DbContextOptions<Contexto>();
        }

        public async Task<IList<Despesa>> ListarDespesaUsuario(string emailUsuario)
        {
            using (var banco = new Contexto(_dbContextOptions))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join c in banco.Categoria on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in banco.Despesa on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                     select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListarDespesaUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            using (var banco = new Contexto(_dbContextOptions))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join c in banco.Categoria on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     join d in banco.Despesa on c.Id equals d.IdCategoria
                     where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                     select d).AsNoTracking().ToListAsync();
            }
        }
    }
}