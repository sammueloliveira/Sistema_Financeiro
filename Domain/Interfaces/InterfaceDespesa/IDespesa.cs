using Domain.Entities;
using Domain.Interface.InterfaceGenerics;

namespace Domain.Interfaces.InterfaceDespesa
{
    public interface IDespesa : IGeneric<Despesa>
    {
        Task<IList<Despesa>> ListarDespesaUsuario(string emailUsuario);
        Task<IList<Despesa>> ListarDespesaUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}