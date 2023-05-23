using Domain.Entities;
using Domain.Interface.InterfaceGenerics;

namespace Domain.Interfaces.InterfaceCategoria
{
    public interface ICategoria : IGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriaUsuario(string emailUsuario);
    }
}