using System;

namespace WebApplication1.Models
{
    public abstract class MovimentacaoEstoque
    {
        public int ID { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public double Qtde { get; set; }

        // adicionar ao diagrama de classe
        public double ValorMovimentacao { get; set; }
    }
}