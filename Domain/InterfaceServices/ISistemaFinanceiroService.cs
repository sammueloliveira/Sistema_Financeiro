using Domain.Entities;

namespace Domain.InterfaceServices
{
    public interface ISistemaFinanceiroService
    {
        Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
        Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
    }
}