namespace NovoCuidar2024.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cuidadora { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
