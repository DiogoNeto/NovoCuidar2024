using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Visita
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("Colaborador")]
        //public int ColaboradorId { get; set; }
        [ForeignKey("Utente")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateTime DataHora { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Observações { get; set; }
        //[ForeignKey("FotosVisita")]
        //public FotosVisita[]? fotosVisita { get; set; }
    }
}
