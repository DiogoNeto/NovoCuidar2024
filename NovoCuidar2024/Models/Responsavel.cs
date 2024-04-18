using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Responsavel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Nif { get; set; }
        [Required]
        public int CC { get; set; }
        [Required]
        public int SNS { get; set; }
        [Required]
        public required string NomePrincipal { get; set; }
        [Required]
        public required string NomeApelido { get; set; }
        [Required]
        public DateOnly DataNascimento { get; set; }
        [Required]
        public required string Nacionalidade { get; set; }
        [Required]
        public char Genero { get; set; }
        [Required]
        public required string Telefone { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Morada { get; set; }
        [Required]
        public required string CodPostal { get; set; }
        [Required]
        public required string Localidade { get; set; }
        [Required]
        public required string Concelho { get; set; }
        [Required]
        public required string EstadoCivil { get; set; }
        public string? Observações { get; set; }
    }
}