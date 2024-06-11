using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class FotosVisita
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Caminho { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
