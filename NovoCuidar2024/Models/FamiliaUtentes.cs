using System.ComponentModel.DataAnnotations;

namespace NovoCuidar2024.Models
{
    public class FamiliaUtentes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
    }
}
