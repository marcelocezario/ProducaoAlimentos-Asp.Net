using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class LoteInsumoProducao
    {
        public int LoteInsumoProducaoID { get; set; }
        public double QtdeInsumo { get; set; }
        public double CustoTotalInsumo { get; set; }

        [ForeignKey("_LoteInsumo")]
        public int LoteInsumoID { get; set; }
        public virtual LoteInsumo _LoteInsumo { get; set; }
    }
}