using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UtenteId { get; set; }
        [Required]
        public string? ServicoContratado { get; set; }
        public string? OrigemContacto { get; set; }
        public string? Descricao { get; set; }
        public string? Preco { get; set; }
        public DateOnly DataServico { get; }

    }
}
