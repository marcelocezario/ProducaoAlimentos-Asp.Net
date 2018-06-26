using System;

namespace WebApplication1.Models
{
    public abstract class MovimentacaoEstoque
    {
        public int ID { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public double Qtde { get; set; }
        public double ValorMovimentacao { get; set; }
    }
}