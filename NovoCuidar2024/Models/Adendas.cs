using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class Adendas
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int ContratoId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Descricao { get; set; }
        public string Ficheiro { get; set; }
    }
}
