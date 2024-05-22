using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly DataAssinatura { get; set; }
        [Required]
        public required string Motivo { get; set; }
        [Required]
        public required string Descricao { get; set; }
        [Required]
        public int Valor { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public int Ficheiro { get; set; }
    }
}
