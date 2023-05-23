using Domain.Entities;

namespace Domain.InterfaceServices
{
    public interface IUsuarioSistemaFinanceiroService
    {
        Task CadastraUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}
