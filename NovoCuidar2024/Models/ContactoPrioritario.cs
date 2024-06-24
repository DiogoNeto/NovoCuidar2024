using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class ContactoPrioritario
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Utente")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Nif { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Nome { get; set; }        
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Parentesco { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Morada { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int NumPorta { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Andar { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Fracao { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Localidade { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string CodPostal { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Pais { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public bool Ativo { get; set; }

    }
}