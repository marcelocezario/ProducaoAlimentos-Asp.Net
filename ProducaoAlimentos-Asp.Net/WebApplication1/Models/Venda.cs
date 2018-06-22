﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Venda
    {
        public int VendaID { get; set; }
        public double ValorTotalVenda { get; set; }
        public DateTime DataVenda { get; set; }

        public virtual List<ItemVenda> _ItensVenda { get; set; }
    }
}