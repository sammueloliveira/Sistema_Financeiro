using Domain.Entities;
using Domain.Interfaces.InterfaceDespesa;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesa _idespesa;
        private readonly IDespesaService _idespesaService;

        public DespesaController(IDespesa idespesa, IDespesaService idespesaService)
        {
            _idespesa = idespesa;
            _idespesaService = idespesaService;
        }

        [HttpGet("/api/ListaDespesaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaDespesaUsuario(string emailUsuario)
        {
            return await _idespesa.ListarDespesaUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarDespesaUsuario")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesaUsuario(Despesa despesa)
        {
            await _idespesaService.AdicionarDespesa(despesa);

            return despesa;
        }

        [HttpPut("/api/AtualizarDespesaUsuario")]
        [Produces("application/json")]
        public async Task<object> AtualizarDespesaUsuario(Despesa despesa)
        {
            await _idespesaService.AtualizarDespesa(despesa);

            return despesa;
        }

        [HttpGet("/api/ObterDespesaUsuario")]
        [Produces("application/json")]
        public async Task<object> ObterDespesaUsuario(int id)
        {
            return await _idespesa.GeTEntityById(id);
        }

        [HttpDelete("/api/DeletarDespesaUsuario")]
        [Produces("application/json")]
        public async Task<object> DeletarDespesaUsuario(int id)
        {
            try
            {
                var despesa = await _idespesa.GeTEntityById(id);

                await _idespesa.Delete(despesa);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [HttpGet("/api/CarregarGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregarGraficos(string emailUsuario)
        {
            return await _idespesaService.CarregaGraficos(emailUsuario);
        }



    }
}
