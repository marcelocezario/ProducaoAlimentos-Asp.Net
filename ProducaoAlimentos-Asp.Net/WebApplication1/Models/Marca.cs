namespace WebApplication1.Models
{
    [Table("Marcas")]
    public class Marca
    {
        public int MarcaID { get; set; }
        public string Nome { get; set; }
    }
}