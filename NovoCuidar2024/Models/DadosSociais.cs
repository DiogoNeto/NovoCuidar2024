using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class DadosSociais
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Utente")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        public string RespostaSocial { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string ApoioSolicitado { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string OutrosApoios { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string ResumoSocial { get; set; }
    }
}
