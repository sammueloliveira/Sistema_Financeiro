using Domain.Entities;
using Domain.Interfaces.InterfaceDespesa;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesa _idespesa;
        public DespesaService(IDespesa despesa)
        {
            _idespesa = despesa;
        }

        public async Task AdicionarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _idespesa.Add(despesa);

        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valido = despesa.ValidaPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _idespesa.Update(despesa);
        }

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            var despesaUsuario = await _idespesa.ListarDespesaUsuario(emailUsuario);
            var despesaAnterior = await _idespesa.ListarDespesaUsuarioNaoPagasMesesAnterior(emailUsuario);

            var despesa_naoPagasMesesAnteriores = despesaAnterior.Any() ?
                despesaAnterior.ToList().Sum(x => x.Valor) : 0;

            var despesa_pagas = despesaUsuario.Where(d => d.Pago && d.Tipo == Enum.TipoDespesa.Contas)
                .Sum(x => x.Valor);

            var despesa_pendentes = despesaUsuario.Where(d => !d.Pago && d.Tipo == Enum.TipoDespesa.Contas)
                .Sum(x => x.Valor);

            var investimentos = despesaUsuario.Where(d => d.Tipo == Enum.TipoDespesa.Investimento)
                .Sum(x => x.Valor);

            return new 
            {
                sucesso = "Ok",
                despesas_pagas = despesa_pagas,
                despesas_pendentes = despesa_pendentes,
                despesas_naoPagasMeseAnteriores = despesa_naoPagasMesesAnteriores,
                investimensto = investimentos
            };
        }
    }
}