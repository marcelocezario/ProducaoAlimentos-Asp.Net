using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Marcas")]
    public class Marca
    {
        [Display(Name = "Id")]
        public int MarcaID { get; set; }
        [Display(Name = "Marca")]
        public string Nome { get; set; }
    }
}