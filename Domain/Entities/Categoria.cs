using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Categoria")]
    public class Categoria : Base
    {
       
        [ForeignKey("SistemaFinanceiro")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
       // public SistemaFinanceiro SistemaFinanceiro { get; set; }
    }
}