using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata;

namespace NovoCuidar2024.Models
{
    public class Utente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdInterno { get; set; }
        [Required]
        public string Nome { get; set; }
        [ForeignKey("Responsavel")]
        public int ResponsavelTecnicoId { get; set; }
        [ForeignKey("FamiliaUtentes")]
        public int FamiliaId { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public int Nif { get; set; }
        [Required]
        public DateOnly DataInscricao { get; set; }
        [Required]
        public string OrigemContrato { get; set; }
        [Required]
        public char Genero { get; set; }
        [Required]
        public DateOnly DataNascimento { get; set; }
        [Required]
        public required string EstadoCivil { get; set; }
        [Required]
        public required string DocIdentificacaoTipo { get; set; }
        [Required]
        public required string DocIdentificacaoNum { get; set; }
        [Required]
        public required DateOnly DocIdentificacaoValidade { get; set; }
        [Required]
        public required string SegurancaSocialNum { get; set; }
        [Required]
        public required string Nacionalidade { get; set; }
        [Required]
        public required string ContactoTelemovel { get; set; }
        [Required]
        public required string ContactoEmail { get; set; }
        [Required]
        public required string Habilitacoes { get; set; }
        [Required]
        public required string Vivencia { get; set; }
        [Required]
        public required string HabitacaoTipo { get; set; }
        [Required]
        public required string HabitacaoPartilhada { get; set; }
        [Required]
        public required string NomeEmpresa { get; set; }

        public required string Foto { get; set; }
       
    }
}
