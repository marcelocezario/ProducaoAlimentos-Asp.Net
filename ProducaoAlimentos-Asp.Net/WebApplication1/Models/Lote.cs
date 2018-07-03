using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public abstract class Lote
    {
        [Display(Name = "Id")]
        public int ID { get; set; }
        [Display(Name = "Qtde inicial")]
        public double QtdeInicial { get; set; }
        [Display(Name = "Qtde disponível")]
        public double QtdeDisponivel { get; set; }
        [Display(Name = "Custo médio unitário")]
        public double CustoMedio { get; set; }
        [Display(Name = "Custo total inicial")]
        public double CustoTotalInicial { get; set; }
        [Display(Name = "Data validade")]
        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }
    }
}