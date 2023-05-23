using Domain.Entities;
using Domain.Interfaces.InterfaceUsuarioSistemaFinanceiro;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly IUsuarioSistemaFinanceiro _iusuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroService _iusuarioSistemaFinanceiroService;

        public UsuarioSistemaFinanceiroController(IUsuarioSistemaFinanceiro usuarioSistemaFinanceiro,
            IUsuarioSistemaFinanceiroService usuarioSistemaFinanceiroService)
        {
            _iusuarioSistemaFinanceiro = usuarioSistemaFinanceiro;
            _iusuarioSistemaFinanceiroService = usuarioSistemaFinanceiroService;
        }

        [HttpGet("/api/ListarUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListarUsuariosSistema(int idSistema)
        {
            return await _iusuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        [HttpPost("/api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _iusuarioSistemaFinanceiroService.CadastraUsuarioNoSistema(
               new UsuarioSistemaFinanceiro
               {
                   IdSistema = idSistema,
                   EmailUsuario = emailUsuario,
                   Administrador = false,
                   SistemaAtual = true
               });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeletarUsuarioNoSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioNoSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _iusuarioSistemaFinanceiro.GeTEntityById(id);

                await _iusuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
