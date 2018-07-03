using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("InsumosComposicaoProdutos")]
    public class InsumoComposicaoProduto
    {
        public int InsumoComposicaoProdutoID { get; set; }
        public double QtdeInsumo { get; set; }

        [Required]
        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        [Required]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
    }
}