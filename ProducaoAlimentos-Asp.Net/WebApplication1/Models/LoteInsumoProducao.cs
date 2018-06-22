using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class LoteInsumoProducao
    {
        public int LoteInsumoProducaoID { get; set; }
        public double QtdeInsumo { get; set; }
        public double CustoInsumo { get; set; }

        [ForeignKey("_LoteInsumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }
    }
}