﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Display(Name = "Id")]
        public int CidadeID { get; set; }
        [Display(Name = "Cidade")]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("_Estado")]
        [Display(Name = "Estado")]
        public int EstadoID { get; set; }
        public virtual Estado _Estado { get; set; }

        public virtual List<Endereco> _Enderecos { get; set; }
    }
}