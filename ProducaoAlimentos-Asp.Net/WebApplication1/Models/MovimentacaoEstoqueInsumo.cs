using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class MovimentacaoEstoqueInsumo : MovimentacaoEstoque
    {
        [ForeignKey("_LoteInsumo")]
        public int LoteInsumoID { get; set; }
        public virtual LoteInsumo _LoteInsumo { get; set; }
    }
}