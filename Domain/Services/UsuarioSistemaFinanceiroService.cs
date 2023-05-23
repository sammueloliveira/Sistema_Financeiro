using Domain.Entities;
using Domain.Interfaces.InterfaceUsuarioSistemaFinanceiro;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class UsuarioSistemaFinanceiroService : IUsuarioSistemaFinanceiroService
    {
        private readonly IUsuarioSistemaFinanceiro _iusuarioSistemaFinanceiro;
        public UsuarioSistemaFinanceiroService(IUsuarioSistemaFinanceiro iusuarioSistemaFinanceiro)
        {
            _iusuarioSistemaFinanceiro = iusuarioSistemaFinanceiro;
        }

        public async Task CadastraUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _iusuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}