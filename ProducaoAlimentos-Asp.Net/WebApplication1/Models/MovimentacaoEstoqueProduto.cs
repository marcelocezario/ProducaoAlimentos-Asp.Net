using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("MovimentacoesEstoqueProdutos")]
    public class MovimentacaoEstoqueProduto : MovimentacaoEstoque
    {
        [ForeignKey("_LoteProduto")]
        public int LoteProdutoID { get; set; }
        public virtual LoteProduto _LoteProduto { get; set; }
    }
}