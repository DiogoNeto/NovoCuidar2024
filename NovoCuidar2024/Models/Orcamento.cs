using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Orcamento
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Utente")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Total { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateTime DataOrcamento { get; set; }
    }
}
