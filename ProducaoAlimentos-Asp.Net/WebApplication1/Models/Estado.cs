using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Estados")]
    public class Estado
    {
        [Display(Name = "Id")]
        public int EstadoID { get; set; }
        [Display(Name = "Estado")]
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}