using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("ItensVendas")]
    public class ItemVenda
    {
        public int ItemVendaID { get; set; }
        public double ValorUnitarioItem { get; set; }
        public double ValorTotalItem { get; set; }
        public double QtdeProduto { get; set; }

        [Required]
        [ForeignKey("_LoteProduto")]
        public int LoteProdutoID { get; set; }
        public virtual LoteProduto _LoteProduto { get; set; }
    }
}