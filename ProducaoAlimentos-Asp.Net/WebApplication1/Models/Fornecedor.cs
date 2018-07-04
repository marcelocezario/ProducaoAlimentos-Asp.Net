using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Fornecedores")]
    public class Fornecedor : Pessoa
    {
        public virtual List<LoteInsumo> _LotesInsumos { get; set; }
    }
}