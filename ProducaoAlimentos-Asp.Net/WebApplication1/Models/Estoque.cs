namespace WebApplication1.Models
{
    public abstract class Estoque
    {
        public int ID { get; set; }
        public double QtdeTotalEstoque { get; set; }
        public double CustoTotalEstoque { get; set; }
    }
}