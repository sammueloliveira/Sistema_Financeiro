using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Notifica
    {
        public Notifica()
        {
            notificacoes = new List<Notifica>();
        }
        [NotMapped]
        public string NomePropriedade { get; set; }
        [NotMapped]
        public string mensagem { get; set; }
        [NotMapped]
        public List<Notifica> notificacoes;

        public bool ValidaPropriedadeString(string valor, string NomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(NomePropriedade))
            {
                notificacoes.Add(new Notifica { mensagem = "Campo obrigatorio", NomePropriedade = NomePropriedade });
                return false;
            }
            return true;

        }
        public bool ValidaPropriedadeInt(int valor, string NomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(NomePropriedade))
            {
                notificacoes.Add(new Notifica { mensagem = "Campo obrigatorio", NomePropriedade = NomePropriedade });
                return false;
            }
            return true;

        }
        public bool ValidaPropriedadeDecimal(decimal valor, string NomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(NomePropriedade))
            {
                notificacoes.Add(new Notifica { mensagem = "Campo obrigatorio", NomePropriedade = NomePropriedade });
                return false;
            }
            return true;

        }
    }
}