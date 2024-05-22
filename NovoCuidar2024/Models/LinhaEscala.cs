using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class LinhaEscala
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CuidadoraId { get; set; }
        [Required]
        public int ServicoContratadoId { get; set; }
        [Required]
        public DateTime DataHoraInicio { get; set; }
        [Required]
        public DateTime DataHoraFim { get; set; }
        [Required]
        public Double ValorReceberInicial { get; set; }
        [Required]
        public Double ValorPago { get; set; }
        [Required]
        public Double ValorReceberAtualizado { get; set; }
    }
}
