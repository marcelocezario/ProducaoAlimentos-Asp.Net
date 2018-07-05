using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public abstract class Estoque
    {
        public int ID { get; set; }

        [Display(Name = "Quantidade em estoque")]
        public double QtdeTotalEstoque { get; set; }

        [Display(Name = "Custo total em estoque")]
        public double CustoTotalEstoque { get; set; }
    }
}