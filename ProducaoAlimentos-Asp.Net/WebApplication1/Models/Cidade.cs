using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Cidade
    {
        [Display(Name = "Id")]
        public int CidadeID { get; set; }
        [Display(Name = "Cidade")]
        public string Nome { get; set; }

        [ForeignKey("_Estado")]
        public int EstadoID { get; set; }
        public virtual Estado _Estado { get; set; }
    }
}