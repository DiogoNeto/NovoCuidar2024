using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class MoradaUtente
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Utente")]
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public string Morada { get; set; }
        [Required]
        public string CodPostal { get; set; }
        [Required]
        public string Localidade {  get; set; }
        [Required]
        public string Concelho {  get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Fracao { get; set; }
        [Required]
        public int Andar { get; set; }
        [Required]
        public int NumPorta { get; set; }
    }
}
