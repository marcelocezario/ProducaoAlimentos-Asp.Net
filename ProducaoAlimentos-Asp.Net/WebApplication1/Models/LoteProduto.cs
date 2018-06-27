using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class LoteProduto : Lote
    {
        public DateTime DataProducao { get; set; }
        public double ValorVendaUnitario { get; set; }

        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }

        public virtual List<LoteInsumoProducao> _ItensInsumoProducao { get; set; }
    }
}