using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Tecnico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Tipo { get; set; }
    }
}
