using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class ServicoContratado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int ServicoId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int ContratoId { get; set;}
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateOnly DataInicio { get; set; }
        public DateOnly? DataFim { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Periodicidade { get; set;}
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public float ValorDia { get; set;}
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public float ValorSemana { get; set;}
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public float ValorMes { get; set;}
    }
}