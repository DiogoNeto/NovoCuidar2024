using NovoCuidar2024.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Utente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int? IdInterno { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string? Nome { get; set; }
        [ForeignKey("Tecnica")]
        public int? ResponsavelTecnicoId { get; set; }
        [ForeignKey("FamiliaUtentes")]
        public int? FamiliaId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int? Nif { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateOnly? DataInscricao { get; set; }
        public string? OrigemContacto { get; set; }
        public char? Genero { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateOnly? DataNascimento { get; set; }
        public string? EstadoCivil { get; set; }
        public string DocIdentificacaoTipo { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string DocIdentificacaoNum { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateOnly? DocIdentificacaoValidade { get; set; }
        public string? SegurancaSocialNum { get; set; }
        public string? Nacionalidade { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string? ContactoTelemovel { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string? ContactoEmail { get; set; }
        public string? Habilitacoes { get; set; }
        public string? Vivencia { get; set; }
        public string? HabitacaoTipo { get; set; }
        public string? HabitacaoPartilhada { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Foto { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string NomeEmpresa { get; set; }
        public List<Visita>? Visita { get; set; }
    }
}
