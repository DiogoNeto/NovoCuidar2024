using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class SubSistema
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int UtenteId { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Nome { get; set;}

    }
}
