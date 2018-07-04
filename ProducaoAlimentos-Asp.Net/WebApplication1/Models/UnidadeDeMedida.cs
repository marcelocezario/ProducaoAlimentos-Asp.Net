using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Unidades de Medida")]
    public class UnidadeDeMedida
    {
        [Display(Name = "Id")]
        public int UnidadeDeMedidaID { get; set; }
        [Display(Name = "Unidade de medida")]
        public string Nome { get; set; }
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        public bool Fracionavel { get; set; }

        public virtual List<Insumo> _Insumos { get; set; }
        public virtual List<Produto> _Produtos { get; set; }
    }
}