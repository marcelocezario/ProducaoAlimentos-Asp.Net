using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Insumos")]
    public class Insumo
    {
        [Required]
        [Display(Name = "Id")]
        public int InsumoID { get; set; }
        [Display(Name = "Insumo")]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("_UnidadeDeMedida")]
        public int UnidadeDeMedidaID { get; set; }
        public virtual UnidadeDeMedida _UnidadeDeMedida { get; set; }

        public virtual List<LoteInsumo> _LotesInsumos { get; set; }
        public virtual List<EstoqueInsumo> _EstoqueInsumos { get; set; }
        public virtual List<InsumoComposicaoProduto> _ComposicaoProdutos { get; set; }
    }
}