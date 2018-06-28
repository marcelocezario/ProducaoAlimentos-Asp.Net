using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class InsumoComposicaoProduto
    {
        public int InsumoComposicaoProdutoID { get; set; }
        public double QtdeInsumo { get; set; }

        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        public int? ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
    }
}