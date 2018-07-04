using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("LotesProdutos")]
    public class LoteProduto : Lote
    {
        public DateTime DataProducao { get; set; }
        public double ValorVendaUnitario { get; set; }

        [Required]
        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }

        public virtual List<LoteInsumoProducao> _LotesInsumoProducao { get; set; }
        public virtual List<MovimentacaoEstoqueProduto> _MovimentacoesEstoqueProdutos { get; set; }
        public virtual List<ItemVenda> _ItensVenda { get; set; }
    }
}