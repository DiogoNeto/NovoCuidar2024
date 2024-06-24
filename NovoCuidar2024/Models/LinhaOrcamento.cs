using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class LinhaOrcamento
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Orcamento")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int OrcamentoId { get; set; }
        [ForeignKey("Utente")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        [ForeignKey("Servico")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int ServicoId { get; set;}
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Preco { get; set;}
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public DateTime Data { get; set;}
    }
}
