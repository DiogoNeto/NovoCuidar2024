using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class FotoVisita
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string? Caminho { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string? Descricao { get; set; }
        [ForeignKey("Visita")]
        public int? VisitaId { get; set; }
    }
}
