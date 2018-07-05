using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("LotesProdutos")]
    public class LoteProduto : Lote
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataProducao { get; set; }

        [Range(0, Double.PositiveInfinity)]
        [Display(Name = "Valor unitário de venda")]
        public double ValorVendaUnitario { get; set; }

        [Required]
        [ForeignKey("_Produto")]
        [Display(Name = "Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }

        public virtual List<LoteInsumoProducao> _LotesInsumoProducao { get; set; }
        public virtual List<MovimentacaoEstoqueProduto> _MovimentacoesEstoqueProdutos { get; set; }
        public virtual List<ItemVenda> _ItensVenda { get; set; }
    }
}