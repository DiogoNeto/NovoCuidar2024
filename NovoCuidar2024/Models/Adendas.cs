using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Adendas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ContratoId { get; set; }
        [Required]
        public string Descricao { get; set; }
        public string Ficheiro { get; set; }
    }
}
