using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public abstract class MovimentacaoEstoque
    {
        public int ID { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data movimentação")]
        public DateTime DataMovimentacao { get; set; }
        [Display(Name = "Quantidade")]
        public double Qtde { get; set; }
        [Display(Name = "Valor movimentação")]
        public double ValorMovimentacao { get; set; }
    }
}