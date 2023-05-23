using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("UsuarioSistemaFinanceiro")]
    public class UsuarioSistemaFinanceiro
    {
        public int Id { get; set; }
        public string EmailUsuario { get; set; }
        public bool Administrador { get; set; }
        public bool SistemaAtual { get; set; }
      
        [ForeignKey("SistemaFinanceiro")]
        [Column(Order =1)]
        public int IdSistema { get; set; }
        public SistemaFinanceiro SistemaFinanceiro { get; set; }
    }
}