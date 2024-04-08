using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class SubSistema
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set;}

    }
}
