using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Colaborador
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Nif { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int CC { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int SNS { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string NomePrincipal { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string NomeApelido { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateOnly DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Nacionalidade { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public char Genero { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Telefone { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Morada { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string CodPostal { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Localidade { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Concelho { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string EstadoCivil { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Tipo { get; set; }
    }
}
