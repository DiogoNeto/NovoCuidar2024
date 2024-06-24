using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class MoradaUtente
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Utente")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Morada { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string CodPostal { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Localidade {  get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Concelho {  get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Pais { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Fracao { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Andar { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int NumPorta { get; set; }
    }
}
