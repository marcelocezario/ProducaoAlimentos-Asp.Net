using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("InsumosComposicaoProdutos")]
    public class InsumoComposicaoProduto
    {
        public int InsumoComposicaoProdutoID { get; set; }
        [Display(Name = "Quantidade Insumo")]
        public double QtdeInsumo { get; set; }

        [Required]
        [ForeignKey("_Insumo")]
        [Display(Name = "Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        [Required]
        [Display(Name = "Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
    }
}