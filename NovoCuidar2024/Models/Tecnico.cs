using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Tecnico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Foto { get; set; }
    }
}
