using NovoCuidar2024.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovoCuidar2024.Models;
using NovoCuidar2024.ViewModel;

namespace NovoCuidar2024.Controllers
{
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventosController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static List<Event> eventos = new List<Event>
        {
            //new Event { Id = 1, Start = DateTime.Now, End = DateTime.Now.AddHours(1), Title = "Consulta 1", Cuidadora = "Maria" }
            //new LinhaEscala { Id = 2, Title = "Event 2", Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1).AddHours(1) }
        };

        public IActionResult Index(int? utenteId)
        {

            return View();
        }

        [HttpGet]
        public IActionResult GetEvents(int? utenteId)
        {
            var query = @"SELECT le.Id, u.id as UtenteId, u.nome as UtenteNome, c.nome as CuidadoraNome, sc.Descricao, le.DataHoraInicio, le.DataHoraFim, le.ValorReceberInicial as ValorReceber, s.Nome as TipoServico FROM linhaescala le
                            LEFT JOIN cuidadora c ON CuidadoraId = c.Id
                            LEFT JOIN servicocontratado sc ON sc.Id = ServicoContratadoId
                            LEFT JOIN utente u ON u.id = sc.utenteId
                            LEFT JOIN servico s ON s.Id = sc.ServicoId
                            WHERE UtenteId =" + utenteId;
            //_context.LinhaEscala
            var result = _context.LinhasEscalaViewModel.FromSqlRaw(query).ToList();

            //var viewModel = new LinhaEscalaViewModel { };
            //IEnumerable<LinhaEscalaViewModel> servicoContratadoViewModels;

            //if (utenteId == null)
            //{
            //    IEnumerable<LinhaEscalaViewModel> listaLinhasEscala = result;
            //    return View(listaLinhasEscala);
            //}
            //else
            //{
            //    IEnumerable<LinhaEscalaViewModel> listaLinhasEscala = result;
            //    return View(listaLinhasEscala.Where(x => x.UtenteId == utenteId));
            //}
            eventos.Clear();
            foreach(var r in result)
            {
                eventos.Add(new Event
                {
                    Id = r.Id,
                    Cuidadora = r.CuidadoraNome,
                    Start = r.DataHoraInicio,
                    End = r.DataHoraFim,
                    Title = r.TipoServico
                });
            }
            return Json(eventos);
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] Event novoEvento)
        {
            novoEvento.Id = eventos.Count + 1;
            eventos.Add(novoEvento);
            //escrever na bd
            return Json(novoEvento);
        }

        [HttpPost]
        public IActionResult DeleteEvent([FromBody] int eventId)
        {
            var eventToDelete = eventos.FirstOrDefault(e => e.Id == eventId);
            if (eventToDelete != null)
            {
                eventos.Remove(eventToDelete);
                //escrever na bd
                return Ok();
            }
            return NotFound();
        }
    }

    //public class Event
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public DateTime Start { get; set; }
    //    public DateTime End { get; set; }
    //}
}
