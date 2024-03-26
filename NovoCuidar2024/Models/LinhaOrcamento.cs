using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class LinhaOrcamento
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Orcamento")]
        [Required]
        public int OrcamentoId { get; set; }
        [ForeignKey("Utente")]
        [Required]
        public int UtenteId { get; set; }
        [ForeignKey("Servico")]
        [Required]
        public int ServicoId { get; set;}
        [Required]
        public int Preco { get; set;}
        [Required]
        public DateTime Data { get; set;}
    }
}
