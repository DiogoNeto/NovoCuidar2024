using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoCuidar2024.Models
{
    public class Utente : Pessoa
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pessoa")]
        public int PessoaId { get; set; }
        [ForeignKey("Responsavel")]
        public int ResponsavelId { get; set; }
        public bool Ativo { get; set; }
        [ForeignKey("Colaborador")]
        public int TecnicoResponsavelId { get; set; }
        public SubSistema? SubSistema { get; set; }
    }
}
