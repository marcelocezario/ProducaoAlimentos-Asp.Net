using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Unidades de Medida")]
    public class UnidadeDeMedida
    {
        public int UnidadeDeMedidaID { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Fracionavel { get; set; }
    }
}