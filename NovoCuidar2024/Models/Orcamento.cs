using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Orcamento
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Utente")]
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public DateTime DataOrcamento { get; set; }
    }
}
