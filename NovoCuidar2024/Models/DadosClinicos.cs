using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class DadosClinicos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string CentroSaude { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string MedicoAssistente { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int NumUtenteSaúde { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string GrupoSanguineo { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Alergias { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string RestricoesAlimentare { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Patologias { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string InformacoessComplementares { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string ResumoClinico { get; set; }
    }
}
