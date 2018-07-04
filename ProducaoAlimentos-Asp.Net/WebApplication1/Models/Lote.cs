using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public abstract class Lote
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Range(0, Double.PositiveInfinity)]
        [Display(Name = "Qtde inicial")]
        public double QtdeInicial { get; set; }

        [Display(Name = "Qtde disponível")]
        public double QtdeDisponivel { get; set; }

        [Display(Name = "Custo médio unitário")]
        public double CustoMedio { get; set; }

        [Range(0, Double.PositiveInfinity)]
        [Display(Name = "Custo total inicial")]
        public double CustoTotalInicial { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Validade { get; set; }
    }
}