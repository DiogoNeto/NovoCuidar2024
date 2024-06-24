using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Tecnico
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Foto { get; set; }
    }
}
