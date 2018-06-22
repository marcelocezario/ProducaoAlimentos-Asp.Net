using System;

namespace WebApplication1.Models
{
    public abstract class Lote
    {
        public int ID { get; set; }
        public double QtdeInicial { get; set; }
        public double QtdeDisponivel { get; set; }
        public double CustoMedio { get; set; }
        public double CustoTotalInicial { get; set; }
        public DateTime Validade { get; set; }
    }
}