using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class ServicoContratado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public int ServicoId { get; set; }
        [Required]
        public int ContratoId { get; set;}
        [Required]
        public DateOnly DataInicio { get; set; }
        public DateOnly? DataFim { get; set; }
        [Required]
        public string Periodicidade { get; set;}
        [Required]
        public string Descricao { get; set; }
        [Required]
        public float ValorDia { get; set;}
        [Required]
        public float ValorSemana { get; set;}
        [Required]
        public float ValorMes { get; set;}
    }
}