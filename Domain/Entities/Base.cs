using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Base : Notifica
    {
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}