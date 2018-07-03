using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Display(Name = "Id")]
        public int ProdutoID { get; set; }
        [Display(Name = "Produto")]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("_UnidadeDeMedida")]
        [Display(Name = "Unidade de medida")]
        public int UnidadeDeMedidaID { get; set; }
        public virtual UnidadeDeMedida _UnidadeDeMedida { get; set; }

        public virtual List<InsumoComposicaoProduto> _ComposicaoProduto { get; set; }
    }
}