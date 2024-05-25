using NovoCuidar2024.Models;

namespace NovoCuidar2024.ViewModel
{
    public class UtentesViewModel
    {
        //public IEnumerable<Utente> Utente { get; set; }
        //public IEnumerable<Tecnico>? Tecnicos { get; set; }
        //public IEnumerable<ServicoContratado>? Servicos { get; set; }

        public int Id { get; set; }
        public string Foto { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public string? NomeTecnica { get; set; }
        public string? Descricao { get; set; }
        public string? Periodicidade { get; set; }

        //public string Tecnica { get; set; }
        //public string Servico { get; set;}
        //public string TipologiaContrato { get; set; }

    }
}
