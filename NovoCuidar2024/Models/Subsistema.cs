using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class SubSistema
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public string Nome { get; set;}

    }
}
