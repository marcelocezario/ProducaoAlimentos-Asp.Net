using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("EstoqueInsumos")]
    public class EstoqueInsumo : Estoque
    {
        [Required]
        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }
    }
}