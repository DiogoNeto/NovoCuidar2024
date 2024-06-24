using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class FamiliaUtentes
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Codigo { get; set; }
    }
}
