using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class LinhaEscala
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int CuidadoraId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int ServicoContratadoId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateTime DataHoraInicio { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateTime DataHoraFim { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public Double ValorReceberInicial { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public Double ValorPago { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public Double ValorReceberAtualizado { get; set; }
    }
}
