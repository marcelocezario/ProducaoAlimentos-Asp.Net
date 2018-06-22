using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class EstoqueProduto : Estoque
    {
        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
    }
}