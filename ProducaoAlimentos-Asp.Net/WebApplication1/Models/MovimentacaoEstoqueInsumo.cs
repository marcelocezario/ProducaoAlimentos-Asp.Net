﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("MovimentacoesEstoqueInsumos")]
    public class MovimentacaoEstoqueInsumo : MovimentacaoEstoque
    {
        [Required]
        [ForeignKey("_LoteInsumo")]
        public int LoteInsumoID { get; set; }
        public virtual LoteInsumo _LoteInsumo { get; set; }
    }
}