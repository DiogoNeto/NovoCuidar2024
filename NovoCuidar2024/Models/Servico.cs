using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int Preco { get; set; }
        [Required]
        public int Tipo { get; set;}
        [Required]
        public DateOnly Data { get;}

    }
}
