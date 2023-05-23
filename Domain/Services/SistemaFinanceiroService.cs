using Domain.Entities;
using Domain.Interfaces.InterfaceSistemaFinanceiro;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class SistemaFinanceiroService : ISistemaFinanceiroService
    {
        private readonly ISistemaFinanceiro _isistemaFinanceiro;
        public SistemaFinanceiroService(ISistemaFinanceiro isistemaFinanceiro)
        {
            _isistemaFinanceiro = isistemaFinanceiro;
        }

        public async Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if (valido)
            {
                var data = DateTime.UtcNow;

                sistemaFinanceiro.DiaFechamento = 1;
                sistemaFinanceiro.Ano = data.Year;
                sistemaFinanceiro.Mes = data.Month;
                sistemaFinanceiro.AnoCopia = data.Year;
                sistemaFinanceiro.MesCopia = data.Month;
                sistemaFinanceiro.GerarCopiaDespesa = true;

                await _isistemaFinanceiro.Add(sistemaFinanceiro);


            }
        }

        public async Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidaPropriedadeString(sistemaFinanceiro.Nome, "Nome");
            if (valido)
            {
                sistemaFinanceiro.DiaFechamento = 1;
                await _isistemaFinanceiro.Update(sistemaFinanceiro);
            }
        }
    }
}