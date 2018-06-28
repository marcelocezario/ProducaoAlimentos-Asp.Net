using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Estado
    {
        public int EstadoID { get; set; }
        [Display(Name = "Estado")]
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}