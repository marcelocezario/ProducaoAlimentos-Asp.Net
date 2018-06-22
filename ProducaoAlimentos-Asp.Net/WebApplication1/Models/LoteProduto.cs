using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class LoteProduto : Lote
    {
        public DateTime DataProducao { get; set; }
        public double ValorVendaUnitario { get; set; }

        public virtual List<LoteInsumoProducao> _ItensInsumoProducao { get; set; }
    }
}