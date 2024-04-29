using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class DadosClinicos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public string CentroSaude { get; set; }
        [Required]
        public string MedicoAssistente { get; set; }
        [Required]
        public int NumUtenteSaúde { get; set; }
        [Required]
        public string GrupoSanguinio { get; set; }
        [Required]
        public string Alergias { get; set; }
        [Required]
        public string RestricoesAlimentare { get; set; }
        [Required]
        public string Patologias { get; set; }
        [Required]
        public string InformacoessComplementares { get; set; }
        [Required]
        public string ResumoClinico { get; set; }
    }
}
