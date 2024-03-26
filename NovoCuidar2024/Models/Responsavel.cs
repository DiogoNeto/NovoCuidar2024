using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Responsavel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pessoa")]
        [Required]
        public bool PessoaId { get; set; }
        [Required]
        public required string Observações { get; set; }
    }
}