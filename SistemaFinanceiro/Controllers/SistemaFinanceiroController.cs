using Domain.Entities;
using Domain.Interfaces.InterfaceSistemaFinanceiro;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Financeiro.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     [Authorize]
     public class SistemaFinanceiroController : ControllerBase
     {
            private readonly ISistemaFinanceiro _isistemaFinanceiro;
            private readonly ISistemaFinanceiroService _isistemaFinanceiroService;

            public SistemaFinanceiroController(ISistemaFinanceiro sistemaFinanceiro,
                ISistemaFinanceiroService sistemaFinanceiroService)
            {
                _isistemaFinanceiro = sistemaFinanceiro;
                _isistemaFinanceiroService = sistemaFinanceiroService;
            }

            [HttpGet("/api/ListarSistemaUsuario")]
            [Produces("application/json")]
            public async Task<object> ListarSistemaUsuario(string emailUsuario)
            {
                return await _isistemaFinanceiro.ListaSistemaUsuario(emailUsuario);
            }

            [HttpPost("/api/AdicionarSistemaFinanceiro")]
            [Produces("application/json")]
            public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
            {
                await _isistemaFinanceiroService.AdicionarSistemaFinanceiro(sistemaFinanceiro);

                return Task.FromResult(sistemaFinanceiro);

            }
            [HttpPut("/api/AtualizarSistemaFinanceiro")]
            [Produces("application/json")]
            public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
            {
                await _isistemaFinanceiroService.AtualizarSistemaFinanceiro(sistemaFinanceiro);

                return Task.FromResult(sistemaFinanceiro);

            }
            [HttpGet("/api/ObterSistemaFinanceiro")]
            [Produces("application/json")]
            public async Task<object> ObterSistemaFinanceiro(int id)
            {
                await _isistemaFinanceiro.GeTEntityById(id);

                return Task.FromResult(id);

            }
            [HttpDelete("/api/DeletarSistemaFinanceiro")]
            [Produces("application/json")]
            public async Task<object> DeleteSistemaFinanceiro(int id)
            {
                try 
                {
                    var sistemaFinanceiro = await _isistemaFinanceiro.GeTEntityById(id);

                    await _isistemaFinanceiro.Delete(sistemaFinanceiro);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;

            }
     }
}
