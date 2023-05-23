using Domain.Entities;
using Domain.Interface.InterfaceGenerics;

namespace Domain.Interfaces.InterfaceSistemaFinanceiro
{
    public interface ISistemaFinanceiro : IGeneric<SistemaFinanceiro>
    {
        Task<IList<SistemaFinanceiro>> ListaSistemaUsuario(string emailUsuario);
    }
}