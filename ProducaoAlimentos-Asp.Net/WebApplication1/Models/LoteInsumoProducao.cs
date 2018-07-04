using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("LotesInsumosProducao")]
    public class LoteInsumoProducao
    {
        public int LoteInsumoProducaoID { get; set; }
        public double QtdeInsumo { get; set; }
        public double CustoTotalInsumo { get; set; }

        [Required]
        [ForeignKey("_LoteInsumo")]
        public int LoteInsumoID { get; set; }
        public virtual LoteInsumo _LoteInsumo { get; set; }

        [Required]
        [ForeignKey("_LoteProduto")]
        public int LoteProdutoID { get; set; }
        public virtual LoteInsumo _LoteProduto { get; set; }
    }
}