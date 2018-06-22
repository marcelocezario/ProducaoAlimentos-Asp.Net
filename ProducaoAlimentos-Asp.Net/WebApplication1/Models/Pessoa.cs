using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Pessoa
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [ForeignKey(_Endereco)]
        public int EnderecoID { get; set; }
        public virtual Endereco _Endereco { get; set; }
    }
}