using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
