using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Colaborador : Pessoa
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pessoa")]
        [Required]
        public int PessoaId { get; set; }
        [Required]
        public string Tipo { get; set; }
    }
}
