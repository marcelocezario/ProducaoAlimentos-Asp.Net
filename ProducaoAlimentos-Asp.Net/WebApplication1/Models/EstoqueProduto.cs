using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("EstoqueProdutos")]
    public class EstoqueProduto : Estoque
    {
        [Required]
        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
    }
}