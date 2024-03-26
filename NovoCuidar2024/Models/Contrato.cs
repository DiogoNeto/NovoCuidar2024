using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Utente")]
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public DateOnly DataInicio { get; set; }
        [Required]
        public DateOnly DataFim { get; set; }
        [Required]
        public required string Motivo { get; set; }
        [Required]
        public int NumeroContrato { get; set; }
        [Required]
        public required string Descricao { get; set; }
        [Required]
        public required string TipoContrato { get; set; }
        [Required]
        public int Valor {  get; set; }
    }
}
