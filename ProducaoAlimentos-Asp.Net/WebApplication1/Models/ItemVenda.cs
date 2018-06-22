using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ItemVenda
    {
        public int ItemVendaID { get; set; }
        public double ValorUnitarioItem { get; set; }
        public double ValorTotalItem { get; set; }
        public double QtdeProduto { get; set; }

        [ForeignKey("_LoteProduto")]
        public int LoteProdutoID { get; set; }
        public virtual LoteProduto _LoteProduto { get; set; }
    }
}