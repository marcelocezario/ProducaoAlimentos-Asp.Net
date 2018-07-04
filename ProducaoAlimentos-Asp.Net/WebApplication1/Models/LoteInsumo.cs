using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("LotesInsumos")]
    public class LoteInsumo : Lote
    {
        [DataType(DataType.Date)]
        [Display(Name = "Data da compra")]
        public DateTime DataCompra { get; set; }

        [Required]
        [ForeignKey("_Insumo")]
        [Display(Name = "Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        [Required]
        [ForeignKey("_Marca")]
        [Display(Name = "Marca")]
        public int MarcaID { get; set; }
        public virtual Marca _Marca { get; set; }

        [Required]
        [ForeignKey("_Fornecedor")]
        [Display(Name = "Fornecedor")]
        public int FornecedorID { get; set; }
        public virtual Fornecedor _Fornecedor { get; set; }
    }
}