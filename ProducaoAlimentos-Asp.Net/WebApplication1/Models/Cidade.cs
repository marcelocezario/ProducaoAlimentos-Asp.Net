using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Cidade
    {
        public int CidadeID { get; set; }
        public string Nome { get; set; }

        [ForeignKey("_Estado")]
        public int EstadoID { get; set; }
        public virtual Estado _Estado { get; set; }
    }
}