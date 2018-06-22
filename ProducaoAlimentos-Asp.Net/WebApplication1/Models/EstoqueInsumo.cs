using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class EstoqueInsumo : Estoque
    {
        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }
    }
}