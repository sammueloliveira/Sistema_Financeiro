using Domain.Entities;
using Domain.Interfaces.InterfaceCategoria;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _icategoria;
        private readonly ICategoriaService _icategoriaService;

        public CategoriaController(ICategoria categoria, 
            ICategoriaService categoriaService)
        {
            _icategoria = categoria;
            _icategoriaService = categoriaService;
        }
        
        [HttpGet("/api/ListarCategoriaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriausuairo(string emailUsuario)
        {
            return await _icategoria.ListarCategoriaUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarCategoriaUsuario")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoriausuairo(Categoria categoria)
        {
            await _icategoriaService.AdicionarCategoria(categoria);

            return categoria;
        }

        [HttpPut("/api/AtualizarCategoriaUsuario")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoriausuairo(Categoria categoria)
        {
            await _icategoriaService.AtualizarCategoria(categoria);

            return categoria;
        }

        [HttpGet("/api/ObterCategoriaUsuario")]
        [Produces("application/json")]
        public async Task<object> ObterCategoriaUsuairo(int id)
        {
           return await _icategoria.GeTEntityById(id);

        }

        [HttpDelete("/api/DeletarCategoriaUsuario")]
        [Produces("application/json")]
        public async Task<object> DeletarCategoriaUsuario(int id)
        {
            try
            {
                var categoria = await _icategoria.GeTEntityById(id);

                await _icategoria.Delete(categoria);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
           
        }
    }
}
