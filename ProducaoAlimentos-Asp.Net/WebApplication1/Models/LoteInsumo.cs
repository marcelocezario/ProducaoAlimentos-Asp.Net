﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("LotesInsumos")]
    public class LoteInsumo : Lote
    {
        public DateTime DataCompra { get; set; }

        [Required]
        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        [Required]
        [ForeignKey("_Marca")]
        public int MarcaID { get; set; }
        public virtual Marca _Marca { get; set; }

        [Required]
        [ForeignKey("_Fornecedor")]
        public int FornecedorID { get; set; }
        public virtual Fornecedor _Fornecedor { get; set; }
    }
}