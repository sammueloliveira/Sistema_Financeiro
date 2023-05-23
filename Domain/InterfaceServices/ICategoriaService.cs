using Domain.Entities;

namespace Domain.InterfaceServices
{
    public interface ICategoriaService
    {
        Task AdicionarCategoria(Categoria categoria);
        Task AtualizarCategoria(Categoria categoria);
    }
}