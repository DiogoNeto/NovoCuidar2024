using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Visita
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Colaborador")]
        [Required]
        public int ColaboradorId { get; set; }
        [ForeignKey("Utente")]
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        public required string Observações { get; set;}
    }
}
