using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class ClienteViewModel
    {
        // Cliente
        [Display(Name = "Cliente")]
        public string ClienteNome { get; set; }
        [Display(Name = "Cpf_Cnpj")]
        public string ClienteCpf_Cnpj { get; set; }
        [Display(Name = "Telefone")]
        public string ClienteTelefone { get; set; }
        [Display(Name = "E-mail")]
        public string ClienteEmail { get; set; }

        //Endereco
        [Display(Name = "Logradouro")]
        public string EnderecoLogradouro { get; set; }
        [Display(Name = "Número")]
        public int EnderecoNumero { get; set; }
        [Display(Name = "Complemento")]
        public string EnderecoComplemento { get; set; }
        [Display(Name = "Bairro")]
        public string EnderecoBairro { get; set; }
        [Display(Name = "Cep")]
        public string EnderecoCep { get; set; }

        [Required]
        [ForeignKey("_EnderecoCidade")]
        [Display(Name = "Cidade")]
        public int EnderecoCidadeID { get; set; }
    }
}