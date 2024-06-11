using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class DadosSociais
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Utente")]
        [Required]
        public int UtenteId { get; set; }
        public string RespostaSocial { get; set; }
        [Required]
        public string ApoioSolicitado { get; set; }
        [Required]
        public string OutrosApoios { get; set; }
        [Required]
        public string ResumoSocial { get; set; }
    }
}
