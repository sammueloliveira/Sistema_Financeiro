using Domain.Entities;
using Domain.Interfaces.InterfaceCategoria;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoria _icategoria;
        public CategoriaService(ICategoria categoria)
        {
            _icategoria = categoria;
        }
        public async Task AdicionarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidaPropriedadeString(categoria.Nome, "Nome");
            if (valido)
                await _icategoria.Add(categoria);
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            var valido = categoria.ValidaPropriedadeString(categoria.Nome, "Nome");
            if (valido)
                await _icategoria.Update(categoria);
        }
    }
}
