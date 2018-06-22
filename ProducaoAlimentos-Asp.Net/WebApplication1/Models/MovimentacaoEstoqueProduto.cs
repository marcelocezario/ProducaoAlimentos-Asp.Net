using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class MovimentacaoEstoqueProduto : MovimentacaoEstoque
    {
        [ForeignKey("_LoteProduto")]
        public int LoteInsumoID { get; set; }
        public virtual LoteProduto _LoteProduto { get; set; }
    }
}