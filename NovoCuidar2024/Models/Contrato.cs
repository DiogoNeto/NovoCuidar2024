using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateOnly DataAssinatura { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Motivo { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public required string Descricao { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Valor { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Ficheiro { get; set; }
    }
}
