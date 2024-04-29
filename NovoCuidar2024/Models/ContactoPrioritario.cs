using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class ContactoPrioritario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public int Nif { get; set; }
        [Required]
        public string Nome { get; set; }        
        [Required]
        public string Parentesco { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Morada { get; set; }
        [Required]
        public int NumPorta { get; set; }
        [Required]
        public int Andar { get; set; }
        [Required]
        public int Fracao { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string CodPostal { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public bool Ativo { get; set; }

    }
}