using Domain.Entities;
using Domain.Interface.InterfaceGenerics;

namespace Domain.Interfaces.InterfaceUsuarioSistemaFinanceiro
{
    public interface IUsuarioSistemaFinanceiro : IGeneric<UsuarioSistemaFinanceiro>
    {
        Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema);
        Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios);
        Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario);
    }
}