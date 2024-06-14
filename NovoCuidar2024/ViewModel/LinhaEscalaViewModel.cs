namespace NovoCuidar2024.ViewModel
{
    public class LinhaEscalaViewModel
    {
        public int Id { get; set; }
        public int? UtenteId { get; set; }
        public string? UtenteNome { get; set; }
        public string? CuidadoraNome { get; set; }
        public string? TipoServico { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public double? ValorReceber { get; set; }
    }
}
