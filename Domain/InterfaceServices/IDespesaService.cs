using Domain.Entities;

namespace Domain.InterfaceServices
{
    public interface IDespesaService
    {
        Task AdicionarDespesa(Despesa despesa);
        Task AtualizarDespesa(Despesa despesa);

        Task<object> CarregaGraficos(string emailUsuario);
    }
}