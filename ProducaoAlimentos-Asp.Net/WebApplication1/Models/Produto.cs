using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }

        [ForeignKey("_UnidadeDeMedida")]
        public int UnidadeDeMedidaID { get; set; }
        public virtual UnidadeDeMedida _UnidadeDeMedida { get; set; }

        public virtual List<InsumoComposicaoProduto> _ComposicaoProduto { get; set; }
    }
}