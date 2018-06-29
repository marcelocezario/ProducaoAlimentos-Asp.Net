using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Insumos")]
    public class Insumo
    {
        public int InsumoID { get; set; }
        public string Nome { get; set; }
        
        [ForeignKey("_UnidadeDeMedida")]
        public int UnidadeDeMedidaID { get; set; }
        public virtual UnidadeDeMedida _UnidadeDeMedida { get; set; }
    }
}